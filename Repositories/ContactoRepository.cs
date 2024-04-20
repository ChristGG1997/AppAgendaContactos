using DB;
using Microsoft.EntityFrameworkCore;

namespace AppAgendaContactosApi.Repositories
{
    // La clase ContactoRepository implementa la interfaz IContactoRepository.
    // Esto significa que esta clase debe contener la implementación de todos los métodos definidos en IContactoRepository.
    public class ContactoRepository : IContactoRepository
    {
        // _context es una instancia de AgendaContactosContext, que es la clase que se utiliza para interactuar con la base de datos.
        private AgendaContactosContext _context;

        // Este es el constructor de la clase. Se llama automáticamente cuando se crea una nueva instancia de ContactoRepository.
        // El parámetro "context" es una instancia de AgendaContactosContext que se pasa al constructor cuando se crea la instancia.
        // Esta instancia se asigna a la variable privada _context para que se pueda utilizar en otros métodos de la clase.
        public ContactoRepository(AgendaContactosContext context)
        {
            _context = context;
        }

        // Este método devuelve todos los contactos de la base de datos.
        public IEnumerable<Contacto> GetAll()
        {
            return _context.Contactos.ToList();
        }

        // Este método devuelve un solo contacto de la base de datos.
        // El contacto que se devuelve es el que tiene el mismo ID que el parámetro "id".
        public Contacto Get(int id)
        {
            return _context.Contactos.Find(id);
        }

        // Este método agrega un nuevo contacto a la base de datos.
        public void Add(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
        }

        // Este método actualiza un contacto existente en la base de datos.
        public void Update(Contacto contacto)
        {
            _context.Entry(contacto).State = EntityState.Modified;
        }

        // Este método elimina un contacto de la base de datos.
        // El contacto que se elimina es el que tiene el mismo ID que el parámetro "id".
        public void Delete(int id)
        {
            var contacto = _context.Contactos.Find(id);
            if (contacto != null)
            {
                _context.Contactos.Remove(contacto);
            }
        }

        // Este método guarda todos los cambios realizados en el contexto de la base de datos.
        // Esto incluye agregar, actualizar y eliminar contactos.
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
