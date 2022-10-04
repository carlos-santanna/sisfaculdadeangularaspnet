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
    [Route("api/professor")]
    public class ProfessoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfessoresController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //        [Route("listar")]
        public async Task<IActionResult> GetAsync()
        {
            IQueryable<Professor> query = _context.Professores;

            query = query.Include(p => p.Disciplinas);

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
            var professor = await _context.Professores
                .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);



            return professor == null ?
                NotFound()
                : Ok(professor)
                ;



        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(
            [FromBody] ProfessorRequest professorRequest
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var professor = new Professor
            {
                Nome = professorRequest.nome,
                DataNascimento = professorRequest.dataNascimento,
                Salario = professorRequest.salario
            };

            try
            {
                await _context.Professores.AddAsync(professor);
                await _context.SaveChangesAsync();
                return Created($"api/professor/{professor.Id}", professor);
            } catch (Exception e)
            {
                return StatusCode(500, e);
            }



        }

        [HttpPut("{id}")]
        //[Route("/{id}")]
        public async Task<IActionResult> PutAsync(
            [FromBody] ProfessorRequest professorRequest,
            [FromRoute] int id
            )
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var professor = await _context.Professores.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (professor == null)
            {
                return NotFound();
            }


            professor.Nome = professorRequest.nome;
            professor.DataNascimento = professorRequest.dataNascimento;
            professor.Salario = professorRequest.salario;


            try
            {
                _context.Professores.Update(professor);
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
            

            var professor = await _context.Professores.FirstOrDefaultAsync(
                x => x.Id == id
                );

            if (professor == null)
            {
                return NotFound();
            }


            


            try
            {
                _context.Professores.Remove(professor);
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
