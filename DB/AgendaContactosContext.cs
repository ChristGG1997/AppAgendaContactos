using Microsoft.EntityFrameworkCore;

namespace DB
{
    // AgendaContactosContext es una clase que hereda de DbContext.
    // DbContext es una clase de Entity Framework Core que representa una sesión con la base de datos.
    // Permite consultar y guardar instancias de tus entidades a la base de datos.
    public class AgendaContactosContext : DbContext
    {
        // Este es el constructor de la clase. Se llama automáticamente cuando se crea una nueva instancia de AgendaContactosContext.
        // El parámetro "options" es una instancia de DbContextOptions<AgendaContactosContext> que se pasa al constructor cuando se crea la instancia.
        // DbContextOptions contiene las opciones de configuración para el contexto de la base de datos.
        // Estas opciones se pasan a la clase base DbContext a través del método base(options).
        public AgendaContactosContext(DbContextOptions<AgendaContactosContext> options) : base(options)
        {

        }

        // Contactos es una propiedad de tipo DbSet<Contacto>.
        // Un DbSet representa una colección de entidades que se pueden consultar desde la base de datos.
        // En este caso, representa la tabla de contactos en la base de datos.
        public DbSet<Contacto> Contactos { get; set; }
    }
}