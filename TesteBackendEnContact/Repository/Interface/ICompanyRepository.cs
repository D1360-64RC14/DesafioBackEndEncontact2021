using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.DataClass.Interface;
using TesteBackendEnContact.PostDataClass.Interface;

namespace TesteBackendEnContact.Repository.Interface {
    public interface ICompanyRepository {
        Task<ICompany> SaveAsync(ICompanyPost company);
        Task DeleteAsync(int id);
        Task<IEnumerable<ICompany>> GetAllAsync();
        Task<ICompany> GetAsync(int id);
    }
}
