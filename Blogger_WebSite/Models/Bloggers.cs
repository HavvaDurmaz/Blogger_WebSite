using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blogger_WebSite.Models
{
    public class Bloggers
    {
   
        
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int id { get; set; }


            [StringLength(100)]           
            public string BlogName { get; set; }

            public string Explanation { get; set; }

            public DateTime PublishDate { get; set; }

            public int UsersId {  get; set; }

            [StringLength(50)]
            public string Images { get; set; }

            public int ReadCount { get; set; }

            public int CategoriesId { get; set; }

            public Categories Categories { get; set; }

            public Users Users { get; set; }

        
    }
}
