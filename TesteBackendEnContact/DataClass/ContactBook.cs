using System.ComponentModel.DataAnnotations;

namespace TesteBackendEnContact.DataClass {
    namespace Interface {
        public interface IContactBook {
            int Id { get; }
            string Name { get; }
        }
    }

    public class ContactBook : Interface.IContactBook {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ContactBook(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}

namespace TesteBackendEnContact.PostDataClass {
    namespace Interface {
        public interface IContactBookPost {
            string Name { get; }
        }
    }

    public class ContactBookPostData : Interface.IContactBookPost {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
