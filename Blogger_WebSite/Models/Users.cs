using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blogger_WebSite.Models
{
    public class Users
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(50)]

        public string NameSurName { get; set; }
        [StringLength(50)]

        public string Eposta { get; set; }
        [StringLength(50)]

        public string Phone { get; set; }

        [StringLength(10)]
        public string Roles { get; set; }


        public IList<Bloggers> Bloggers { get; set; }

        public IList<Projects> Projects { get; set; }

        public string Sifre { get; set; }

        
    }
}
