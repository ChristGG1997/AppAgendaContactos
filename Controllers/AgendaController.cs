using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAgendaContactosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private AgendaContactosContext _context;

        public AgendaController(AgendaContactosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Contacto> Get() => _context.Contactos.ToList();

        [HttpGet("{id}")]
        public Contacto Get(int id)
        {
            return _context.Contactos.Find(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contacto contacto)
        {
            try
            {
                _context.Contactos.Add(contacto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return CreatedAtAction(nameof(Get), new { id = contacto.id }, new { contacto = contacto, mensaje = $"Creado correctamente el contacto {contacto.Nombre}" });

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contacto contacto)
        {
            if (id != contacto.id)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                _context.Entry(contacto).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(new { mensaje = $"Actualizado correctamente el contacto {contacto.Nombre}" });

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contacto = _context.Contactos.Find(id);

            if (contacto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            try
            {
                _context.Contactos.Remove(contacto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(new { mensaje = $"Eliminado correctamente el contacto {contacto.Nombre}" });

        }
    }
}
