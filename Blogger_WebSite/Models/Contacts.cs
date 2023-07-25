using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blogger_WebSite.Models
{
    public class Contacts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)]
        public string AdSoyad { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefon { get; set; }

        [StringLength(30)]
        public string Meslek { get; set; }

        public string Mesaj { get; set; }
    }
}
