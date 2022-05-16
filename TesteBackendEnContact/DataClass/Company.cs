using System.ComponentModel.DataAnnotations;

namespace TesteBackendEnContact.DataClass {
    namespace Interface {
        public interface ICompany {
            int Id { get; }
            int ContactBookId { get; }
            string Name { get; }
        }
    }

    public class Company : Interface.ICompany {
        public int Id { get; private set; }
        public int ContactBookId { get; private set; }
        public string Name { get; private set; }

        public Company(int id, int contactBookId, string name) {
            Id = id;
            ContactBookId = contactBookId;
            Name = name;
        }
    }
}

namespace TesteBackendEnContact.PostDataClass {
    namespace Interface {
        public interface ICompanyPost {
            int ContactBookId { get; }
            string Name { get; }
        }
    }

    public class CompanyPostData : Interface.ICompanyPost {
        [Required]
        public int ContactBookId { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}