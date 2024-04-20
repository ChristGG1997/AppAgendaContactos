using AppAgendaContactosApi.Repositories;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppAgendaContactosApi.Controllers
{
    // Esta clase es un controlador de API. Maneja las solicitudes HTTP que llegan a la ruta "api/[controller]".
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        // _repo es una instancia de IContactoRepository, que es la interfaz para el repositorio de contactos.
        private IContactoRepository _repo;

        // Este es el constructor de la clase. Se llama automáticamente cuando se crea una nueva instancia de AgendaController.
        // El parámetro "repo" es una instancia de IContactoRepository que se pasa al constructor cuando se crea la instancia.
        // Esta instancia se asigna a la variable privada _repo para que se pueda utilizar en otros métodos de la clase.
        public AgendaController(IContactoRepository repo)
        {
            _repo = repo;
        }

        // Este método maneja las solicitudes GET a la ruta "api/[controller]".
        // Devuelve una lista de todos los contactos.
        [HttpGet]
        public ActionResult<IEnumerable<Contacto>> Get()
        {
            try
            {
                return Ok(_repo.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Este método maneja las solicitudes GET a la ruta "api/[controller]/{id}".
        // Devuelve el contacto con el ID especificado.
        [HttpGet("{id}")]
        public ActionResult<Contacto> Get(int id)
        {
            try
            {
                var contacto = _repo.Get(id);

                if (contacto == null)
                {
                    return NotFound();
                }

                return contacto;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Este método maneja las solicitudes POST a la ruta "api/[controller]".
        // Agrega un nuevo contacto a la base de datos.
        [HttpPost]
        public IActionResult Post([FromBody] Contacto contacto)
        {
            try
            {
                _repo.Add(contacto);
                _repo.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return CreatedAtAction(nameof(Get), new { id = contacto.id }, new { contacto = contacto, mensaje = $"Creado correctamente el contacto {contacto.Name}" });
        }

        // Este método maneja las solicitudes PUT a la ruta "api/[controller]/{id}".
        // Actualiza el contacto con el ID especificado.
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contacto contacto)
        {
            if (id != contacto.id)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                _repo.Update(contacto);
                _repo.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(new { mensaje = $"Actualizado correctamente el contacto {contacto.Name}" });
        }

        // Este método maneja las solicitudes DELETE a la ruta "api/[controller]/{id}".
        // Elimina el contacto con el ID especificado.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var contacto = _repo.Get(id);

            if (contacto == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            try
            {
                _repo.Delete(id);
                _repo.SaveChanges();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Ok(new { mensaje = $"Eliminado correctamente el contacto {contacto.Name}" });
        }
    }
}
