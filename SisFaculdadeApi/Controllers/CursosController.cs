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
    [Route("api/curso")]
    public class CursosController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public CursosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //        [Route("listar")]
        public async Task<IActionResult> GetAsync()
        {
            IQueryable<Curso> query = _context.Cursos;

            //query = query.Include(p => p.Disciplinas);

            query = query.AsNoTracking()
                .OrderBy(p => p.Nome);

            return Ok(await query.ToListAsync());
            //teste
        }

        [HttpGet("disciplinas")]        
        public async Task<IActionResult> GetCursoComDisciplinasAsync()
        {
            IQueryable<Curso> query = _context.Cursos;

            query = query.Include(p => p.CursosDisciplinas);

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
                    from c in _context.Cursos
                    join cd in _context.CursosDisciplinas on c.Id equals cd.CursoId into cgj
                    from cs in cgj.DefaultIfEmpty()
                    join d in _context.Disciplinas on cs.DisciplinaId equals d.Id into cdj2
                    from csd in cdj2.DefaultIfEmpty()
                    join da in _context.DisciplinasAlunos on new { DisciplinaId = csd.Id, CursoId = cs.CursoId } equals new {DisciplinaId = da.DisciplinaId, CursoId = da.CursoId } into csdacac2
                    from csdacac in csdacac2.DefaultIfEmpty()
                    join ac in _context.AlunosCursos on c.Id equals ac.CursoId into csdac2
                    from csdac in csdac2.DefaultIfEmpty()
                    select new { 
                        c.Id,
                        c.Nome,
                        DisciplinaId = cs.DisciplinaId,
                        csd.ProfessorId,                        
                        AlunoId = csdac.AlunoId,
                        csdacac.Nota
                    }
                )
                .GroupBy(
                    x => new { x.Id, x.Nome}
                )
                .Select(x=> new { 
                    curso = x.Key,
                    disciplinas = x.Select(y=>y.DisciplinaId).Distinct().Count()
                    ,alunos = x.Select(z => z.AlunoId).Distinct().Count()
                    ,professores = x.Select(w => w.ProfessorId).Distinct().Count(),
                    media = x.Select(w => w.Nota).Average()
                })
                ;




            query = query.AsNoTracking()
                .OrderBy(p => p.curso.Nome);

            return Ok(await query.ToListAsync());
            //teste
        }

        [HttpGet("{id}/disciplinas")]
        public async Task<IActionResult> GetCursoDisciplinaAsync([FromRoute] int id)
        {

            var query = (
                    from c in _context.Cursos
                    join cd in _context.CursosDisciplinas on c.Id equals cd.CursoId into cd1_
                    from cd1 in cd1_.DefaultIfEmpty()
                    join d in _context.Disciplinas on cd1.DisciplinaId equals d.Id into cd2_
                    from cd2 in cd2_.DefaultIfEmpty()
                    join p in _context.Professores on cd2.ProfessorId equals p.Id into cd3_
                    from cd3 in cd3_.DefaultIfEmpty()                                        
                    join ads in _context.DisciplinasAlunos on new {CursoId = cd1.CursoId, DisciplinaId = cd2.Id} equals new { CursoId = ads.CursoId, DisciplinaId = ads.DisciplinaId} into cd6_
                    from cd6 in cd6_.DefaultIfEmpty()
                    select new
                    {
                        c.Id,
                        c.Nome,
                        DisciplinaId = cd1.DisciplinaId,
                        Disciplina = cd2.Nome,
                        cd2.ProfessorId,
                        ProfessorNome = cd3.Nome,
                        AlunoId = cd6.AlunoId,
                        Nota = cd6.Nota

                    }
                )
            .Where(x => x.Id == id)
            .GroupBy(
                    x => new { x.Id, x.Nome, x.DisciplinaId, x.Disciplina, x.ProfessorId,x.ProfessorNome }
                )
                .Select(x => new {
                    disciplina = x.Key,
                    alunos = x.Select(y => y.AlunoId).Count()
                    ,
                    media = x.Select(z => z.Nota).Average()                    
                })
                ;
            ;
            




            query = query.AsNoTracking()
            .OrderBy(p => p.disciplina.Nome);

            return Ok(await query.ToListAsync());
        }


        [HttpGet("{id}/alunos")]
        public async Task<IActionResult> GetAlunosDisciplinaAsync([FromRoute] int id)
        {
            var query = (
                    from c in _context.Cursos                    
                    join ac in _context.AlunosCursos on c.Id equals ac.CursoId
                    join a in _context.Alunos on ac.AlunoId equals a.Id
                    select new
                    {
                        c.Id,
                        c.Nome,                        
                        ac.AlunoId,
                        Aluno = a.Nome,
                        DtNascimento = a.DataNascimento
                    }
                )
            .Where(x => x.Id == id);




            query = query.AsNoTracking()
            .OrderBy(p => p.Aluno);

            return Ok(await query.ToListAsync());
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id
            )
        {
            var curso = await _context.Cursos.Include(x=> x.CursosDisciplinas)
                .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);



            return curso == null ?
                NotFound()
                : Ok(curso)
                ;



        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] CursoRequest cursoRequest
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();
            
            var disciplinas = cursoRequest.disciplinas;

            var curso = new Curso
            {
                Nome = cursoRequest.nome
            };

            try
            {
                var cursoDisciplina = new List<CursoDisciplina>();
                await _context.Cursos.AddAsync(curso);
                await _context.SaveChangesAsync();
                

                if ((disciplinas!=null) && disciplinas.Length > 0)
                {
                    foreach(int d in disciplinas)
                    {                          
                        await _context.CursosDisciplinas.AddAsync(new CursoDisciplina(curso.Id, d));
                    }
                    await _context.SaveChangesAsync();
                }
                return Created($"api/curso/{curso.Id}", curso);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        [HttpPut("{id}")]
        //[Route("/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] CursoRequest cursoRequest,
            [FromRoute] int id
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var curso = await _context.Cursos.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (curso == null)
            {
                return NotFound();
            }


            curso.Nome = cursoRequest.nome;
            


            try
            {
                _context.Cursos.Update(curso);
                await _context.SaveChangesAsync();


                var cursoDisciplina = _context.CursosDisciplinas.Where(
                    x => x.CursoId == curso.Id
                );

                if (cursoDisciplina != null)
                {
                    _context.CursosDisciplinas.RemoveRange(cursoDisciplina);
                    await _context.SaveChangesAsync();
                }


                

                var disciplinas = cursoRequest.disciplinas;
                if ((disciplinas != null) && disciplinas.Length > 0)
                {
                    foreach (int d in disciplinas)
                    {
                        await _context.CursosDisciplinas.AddAsync(new CursoDisciplina(curso.Id, d));
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
            [FromRoute] int id
            )
        {
            var curso = await _context.Cursos.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (curso == null)
            {
                return NotFound();
            }


            


            try
            {
                _context.Cursos.Remove(curso);
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
