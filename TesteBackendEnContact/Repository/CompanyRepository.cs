using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteBackendEnContact.DataClass;
using TesteBackendEnContact.DataClass.Interface;
using TesteBackendEnContact.PostDataClass.Interface;
using TesteBackendEnContact.Repository.Interface;

namespace TesteBackendEnContact.Repository {
    public class CompanyRepository : ICompanyRepository {
        private readonly SqliteConnection repository;

        public CompanyRepository(SqliteConnection dbConnection) {
            this.repository = dbConnection;
        }

        public async Task<ICompany> SaveAsync(ICompanyPost company) {
            var dao = new CompanyDao(company);

            if (dao.Id == 0)
                dao.Id = await repository.InsertAsync(dao);
            else
                await repository.UpdateAsync(dao);

            return dao.Export();
        }

        public async Task DeleteAsync(int id) {
            await using var transaction = repository.BeginTransaction();

            var sql = new StringBuilder();
            sql.AppendLine("DELETE FROM Company WHERE Id = @id;");
            sql.AppendLine("UPDATE Contact SET CompanyId = null WHERE CompanyId = @id;");

            await repository.ExecuteAsync(sql.ToString(), new { id }, transaction);
        }

        public async Task<IEnumerable<ICompany>> GetAllAsync() {
            var query = "SELECT * FROM Company";
            var result = await repository.QueryAsync<CompanyDao>(query);

            return result?.Select(item => item.Export());
        }

        public async Task<ICompany> GetAsync(int id) {
            var query = "SELECT * FROM Company where Id = @id";
            var result = await repository.QuerySingleOrDefaultAsync<CompanyDao>(query, new { id });

            return result?.Export();
        }
    }

    [Table("Company")]
    public class CompanyDao : ICompany {
        [Key]
        public int Id { get; set; }
        public int ContactBookId { get; set; }
        public string Name { get; set; }

        public CompanyDao() {
        }

        public CompanyDao(ICompanyPost company) {
            ContactBookId = company.ContactBookId;
            Name = company.Name;
        }

        public CompanyDao(ICompany company) {
            Id = company.Id;
            ContactBookId = company.ContactBookId;
            Name = company.Name;
        }

        public ICompany Export() => new Company(Id, ContactBookId, Name);
    }
}
