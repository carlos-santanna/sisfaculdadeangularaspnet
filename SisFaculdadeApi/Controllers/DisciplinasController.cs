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
    [Route("api/disciplina")]
    public class DisciplinasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DisciplinasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //        [Route("listar")]
        public async Task<IActionResult> GetAsync()
        {
            IQueryable<Disciplina> query = _context.Disciplinas;

            query = query.Include(p => p.Professor);

            query = query.AsNoTracking()
                .OrderBy(p => p.Nome);

            return Ok(await query.ToListAsync());
            //teste
        }

        [HttpGet("resumo")]
        //        [Route("listar")]
        public async Task<IActionResult> GetCursoDisciplinaAsync()
        {
            var query = (
                    from d in _context.Disciplinas
                    join cd in _context.CursosDisciplinas on d.Id equals cd.DisciplinaId into cd1_
                    from cd1 in cd1_.DefaultIfEmpty()
                    join da in _context.DisciplinasAlunos on new {CursoId = cd1.CursoId, DisciplinaId = cd1.DisciplinaId } equals new { CursoId = da.CursoId, DisciplinaId = da.DisciplinaId } into cd2_
                    from cd2 in cd2_.DefaultIfEmpty()
                    select new
                    {
                        d.Id,
                        d.Nome,
                        CursoId = cd1.CursoId,
                        d.ProfessorId,
                        //Disciplina = d.Nome,
                        AlunoId = cd2.AlunoId,
                        cd2.Nota
                    }
                )
                .GroupBy(
                    x => new { x.Id, x.Nome }
                )
                .Select(x => new {
                    disciplina = x.Key,
                    cursos = x.Select(y => y.CursoId).Distinct().Count()
                    ,
                    alunos = x.Select(z => z.AlunoId).Distinct().Count()
                    ,
                    professores = x.Select(w => w.ProfessorId).Distinct().Count(),
                    media = x.Select(w => w.Nota).Average()
                })
                ;




            query = query.AsNoTracking()
                .OrderBy(p => p.disciplina.Nome);

            return Ok(await query.ToListAsync());
            //teste
        }

        //retorna todos os alunos matriculados em um
        [HttpGet("{id}/alunos")]
        public async Task<IActionResult> GetAlunosDisciplinaAsync([FromRoute] int id)
        {
            var query = (
                    from d in _context.Disciplinas
                    join dc in _context.CursosDisciplinas on d.Id equals dc.DisciplinaId into cd1_
                    from cd1 in cd1_.DefaultIfEmpty()
                    join c in _context.Cursos on cd1.CursoId equals c.Id into cd2_
                    from cd2 in cd2_.DefaultIfEmpty()
                    join da in _context.DisciplinasAlunos on new { CursoId = cd1.CursoId, DisciplinaId = cd1.DisciplinaId } equals new { CursoId = da.CursoId, DisciplinaId = da.DisciplinaId } into cd3_
                    from cd3 in cd3_.DefaultIfEmpty()                    
                    join a in _context.Alunos on cd3.AlunoId equals a.Id into cd4_
                    from cd4 in cd4_.DefaultIfEmpty()                    
                    select new
                    {
                        d.Id,
                        d.Nome,
                        cd1.CursoId,
                        Curso = cd2.Nome,
                        cd3.AlunoId,
                        Aluno = cd4.Nome,
                        DtNascimento = cd4.DataNascimento
                        ,cd3.Nota
                    }
                )
            .Where(x => x.Id == id)
            
            ;




            query = query.AsNoTracking()
            .OrderBy(p => p.Aluno);

            return Ok(await query.ToListAsync());
        }


        //retorna todos os alunos matriculados em um
        [HttpGet("{id}/{idCurso}/alunos")]
        public async Task<IActionResult> GetAlunosCursoDisciplinaAsync(
            [FromRoute] int id, [FromRoute] int idCurso)
        {
            var query = (
                    from d in _context.Disciplinas
                    join dc in _context.CursosDisciplinas on d.Id equals dc.DisciplinaId
                    join c in _context.Cursos on dc.CursoId equals c.Id
                    join ac in _context.AlunosCursos on c.Id equals ac.CursoId
                    join a in _context.Alunos on ac.AlunoId equals a.Id
                    join da in _context.DisciplinasAlunos on new { DisciplinaId = d.Id, AlunoId = ac.AlunoId } equals new { DisciplinaId = da.DisciplinaId, AlunoId = da.AlunoId }
                    select new
                    {
                        d.Id,
                        d.Nome,
                        dc.CursoId,
                        Curso = c.Nome,
                        ac.AlunoId,
                        Aluno = a.Nome,
                        DtNascimento = a.DataNascimento,
                        da.Nota
                    }
                )
            .Where(x => x.Id == id && x.CursoId==idCurso)

            ;




            query = query.AsNoTracking()
            .OrderBy(p => p.Aluno);

            return Ok(await query.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id
            )
        {
            var disciplina = await _context.Disciplinas
                .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);



            return disciplina == null ?
                NotFound()
                : Ok(disciplina)
                ;



        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] DisciplinaRequest disciplinaRequest
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var disciplina = new Disciplina
            {
                Nome = disciplinaRequest.nome,
                ProfessorId = disciplinaRequest.professorId
            };

            try
            {
                await _context.Disciplinas.AddAsync(disciplina);
                await _context.SaveChangesAsync();
                return Created($"api/disciplina/{disciplina.Id}", disciplina);
            } catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        [HttpPut("{id}")]
        //[Route("/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] DisciplinaRequest disciplinaRequest,
            [FromRoute] int id
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (disciplina == null)
            {
                return NotFound();
            }


            disciplina.Nome = disciplinaRequest.nome;
            disciplina.ProfessorId = disciplinaRequest.professorId;



            try
            {
                _context.Disciplinas.Update(disciplina);
                await _context.SaveChangesAsync();
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
            [FromRoute] int id
            )
        {
            

            var disciplina = await _context.Disciplinas.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (disciplina == null)
            {
                return NotFound();
            }


            


            try
            {
                _context.Disciplinas.Remove(disciplina);
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
