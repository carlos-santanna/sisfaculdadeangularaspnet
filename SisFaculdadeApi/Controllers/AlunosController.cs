using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SisFaculdadeApi.Data;
using SisFaculdadeApi.Models;
using SisFaculdadeApi.RequestsModels;

namespace SisFaculdadeApi.Controllers
{
    [ApiController]
    [Route("api/aluno")]
    public class AlunosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlunosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //        [Route("listar")]
        public async Task<IActionResult> GetAsync()
        {
            IQueryable<Aluno> query = _context.Alunos;

            query = query.Include(p => p.AlunosCursos);

            query = query.AsNoTracking()
                .OrderBy(p => p.Nome);

            return Ok(await query.ToListAsync());
            //teste
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id
            )
        {
            var aluno = await _context.Alunos.Include(p => p.AlunosCursos)
                .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);



            return aluno == null ?
                NotFound()
                : Ok(aluno)
                ;



        }

        [HttpGet("{id}/disciplinas")]
        public async Task<IActionResult> GetDisciplinasByIdAlunoAsync(
            [FromRoute] int id
            )
        {
            var query = (
                    from ac in _context.DisciplinasAlunos
                    join c in _context.Cursos on ac.CursoId equals c.Id into c1_
                    from c1 in c1_.DefaultIfEmpty()
                    join d in _context.Disciplinas on ac.DisciplinaId equals d.Id into cd2_
                    from cd2 in cd2_.DefaultIfEmpty()
                    join p in _context.Professores on cd2.ProfessorId equals p.Id into cd3_
                    from cd3 in cd3_.DefaultIfEmpty()
                    select new
                    {
                        AlunoId = ac.AlunoId,
                        ac.DisciplinaId,
                        cd2.Nome,
                        CursoId = c1.Id,
                        Curso = cd2.Nome,
                        cd2.ProfessorId,
                        ProfessorNome = cd3.Nome,
                        Nota = ac.Nota

                    }
                )
            .Where(x => x.AlunoId == id);

            query = query.AsNoTracking()
            .OrderBy(p =>  p.Curso )
            .ThenBy(p => p.Nome);

            return Ok(await query.ToListAsync());


        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] AlunoRequest alunoRequest
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var aluno = new Aluno
            {
                Nome = alunoRequest.nome,
                DataNascimento = alunoRequest.dataNascimento,                
            };

            try
            {
                await _context.Alunos.AddAsync(aluno);
                await _context.SaveChangesAsync();

                var cursos = alunoRequest.cursos;

                var alunoCurso = new List<AlunoCurso>();

                if ((cursos != null) && cursos.Length > 0)
                {
                    foreach (int d in cursos)
                    {
                        await _context.AlunosCursos.AddAsync(new AlunoCurso(aluno.Id, d));
                    }
                    await _context.SaveChangesAsync();
                }
                return Created($"api/aluno/{aluno.Id}", aluno);
            } catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        [HttpPut("{id}")]
        //[Route("/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] AlunoRequest alunoRequest,
            [FromRoute] int id
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var aluno = await _context.Alunos.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (aluno == null)
            {
                return NotFound();
            }


            aluno.Nome = alunoRequest.nome;
            aluno.DataNascimento = alunoRequest.dataNascimento;
            
            try
            {
                _context.Alunos.Update(aluno);
                await _context.SaveChangesAsync();

                var alunoCursos = _context.AlunosCursos.Where(
                    x => x.AlunoId == aluno.Id
                );

                if (alunoCursos != null)
                {
                    _context.AlunosCursos.RemoveRange(alunoCursos);
                    await _context.SaveChangesAsync();
                }

                var cursos = alunoRequest.cursos;
                if ((cursos != null) && cursos.Length > 0)
                {
                    foreach (int d in cursos)
                    {
                        await _context.AlunosCursos.AddAsync(new AlunoCurso(aluno.Id, d));
                    }
                    await _context.SaveChangesAsync();
                }


                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        [HttpDelete("{id}")]
        //[Route("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromBody] AlunoRequest alunoRequest,
            [FromRoute] int id
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var aluno = await _context.Alunos.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (aluno == null)
            {
                return NotFound();
            }


            


            try
            {
                _context.Alunos.Remove(aluno);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        [HttpPut("atualizar/nota")]
        //[Route("/{id}")]
        public async Task<IActionResult> PutAsyNotasnc(            
            [FromBody] CursoDisciplinaNotasRequest[] arrNotas
            )
        {
            Console.WriteLine(arrNotas);

            if (arrNotas.Length<=0)
            {
                return BadRequest();

            }


            try
            {

                foreach (CursoDisciplinaNotasRequest d in arrNotas)
                {
                    var disciplinaAluno = _context.DisciplinasAlunos.Where(
                        x => (x.CursoId == d.cursoId) && (x.AlunoId == d.alunoId) && (x.DisciplinaId == d.disciplinaId)
                    );
                    if (disciplinaAluno != null)
                    {
                        //muda a nota
                        if (d.nota <= 0.0)
                        {
                            d.nota = 0.0;
                        }else if (d.nota>10.0)
                        {
                            d.nota = 10.0;
                        }
                        disciplinaAluno.ToList().ForEach(item => item.Nota = d.nota);

                        _context.DisciplinasAlunos.UpdateRange(disciplinaAluno);                        
                    }
                    
                }
                await _context.SaveChangesAsync();
                


                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }


    }
}
