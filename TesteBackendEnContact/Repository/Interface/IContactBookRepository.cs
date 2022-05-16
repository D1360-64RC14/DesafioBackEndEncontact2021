using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.DataClass.Interface;

namespace TesteBackendEnContact.Repository.Interface {
    public interface IContactBookRepository {
        Task<IContactBook> SaveAsync(IContactBook contactBook);
        Task DeleteAsync(int id);
        Task<IEnumerable<IContactBook>> GetAllAsync();
        Task<IContactBook> GetAsync(int id);
    }
}
