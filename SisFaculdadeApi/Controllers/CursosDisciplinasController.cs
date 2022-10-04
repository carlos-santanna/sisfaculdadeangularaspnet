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
    [Route("api/curso-disciplina")]
    public class CursosDisciplinasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursosDisciplinasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //        [Route("listar")]
        public async Task<IActionResult> GetAsync()
        {
            IQueryable<CursoDisciplina> query = _context.CursosDisciplinas;

            //query = query.Include(p => p.CursosDisciplinas);

            query = query.AsNoTracking()
                .OrderBy(p => p.CursoId);

            return Ok(await query.ToListAsync());
            //teste
        }


        //busca por disciplina
        [HttpGet("disciplina/{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id
            )
        {
            var cursoDisciplina = await _context.CursosDisciplinas
                .AsNoTracking()
            .FirstOrDefaultAsync(x => x.DisciplinaId == id);



            return cursoDisciplina == null ?
                NotFound()
                : Ok(cursoDisciplina)
                ;



        }

        //busca por disciplina
        [HttpGet("curso/{id}")]
        public async Task<IActionResult> GetByCursoIdAsync(
            [FromRoute] int id
            )
        {
            var cursoDisciplina = await _context.CursosDisciplinas
                .AsNoTracking()
            .FirstOrDefaultAsync(x => x.CursoId == id);



            return cursoDisciplina == null ?
                NotFound()
                : Ok(cursoDisciplina)
                ;



        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] CursoDisciplinaRequest cursoDisciplinaRequest
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cursoDisciplina = new CursoDisciplina
            {
                CursoId = cursoDisciplinaRequest.cursoId,
                DisciplinaId = cursoDisciplinaRequest.disciplinaId
            };

            try
            {
                await _context.CursosDisciplinas.AddAsync(cursoDisciplina);
                await _context.SaveChangesAsync();
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        
        //remove por
        [HttpDelete("{idCurso}/{idDisciplina}")]
        //[Route("{id}")]
        public async Task<IActionResult> DeleteAsync(            
            [FromRoute] int idCurso, [FromRoute] int idDisciplina
            )
        {
            
            var cursoDisciplina = _context.CursosDisciplinas.Where(
                x => x.CursoId == idCurso && x.DisciplinaId == idDisciplina
                );

            if (cursoDisciplina == null)
            {
                return NotFound();
            }


            


            try
            {
                _context.CursosDisciplinas.RemoveRange(cursoDisciplina);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }



        //remove por curso
        [HttpDelete("curso/{idCurso}")]
        //[Route("{id}")]
        public async Task<IActionResult> DeleteByCursoAsync(
            [FromRoute] int idCurso
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cursoDisciplina = _context.CursosDisciplinas.Where(
                x => x.CursoId == idCurso
                );

            if (cursoDisciplina == null)
            {
                return NotFound();
            }





            try
            {
                _context.CursosDisciplinas.RemoveRange(cursoDisciplina);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        //remove por curso
        [HttpDelete("disciplina/{idDisciplina}")]
        //[Route("{id}")]
        public async Task<IActionResult> DeleteByidDisciplinaAsync(
            [FromRoute] int idCurso
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cursoDisciplina = _context.CursosDisciplinas.Where(
                x => x.CursoId == idCurso
                );

            if (cursoDisciplina == null)
            {
                return NotFound();
            }





            try
            {
                _context.CursosDisciplinas.RemoveRange(cursoDisciplina);
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
