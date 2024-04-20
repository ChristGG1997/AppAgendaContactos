using DB;

namespace AppAgendaContactosApi.Repositories
{
    // IContactoRepository es una interfaz que define los métodos que un repositorio de contactos debe tener.

    // Cualquier clase que implemente IContactoRepository debe proporcionar una implementación para todos estos métodos.
    public interface IContactoRepository
    {
        IEnumerable<Contacto> GetAll();
        Contacto Get(int id);
        void Add(Contacto contacto);
        void Update(Contacto contacto);
        void Delete(int id);
        void SaveChanges();
    }
}
