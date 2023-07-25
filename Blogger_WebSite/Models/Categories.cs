using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogger_WebSite.Models
{
    public class Categories
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(30)]
        public string CategoryName { get; set; }

        [StringLength(30)]
        public string Images { get; set; }
     

        public IList<Bloggers> Bloggers { get; set; }
    }
}
