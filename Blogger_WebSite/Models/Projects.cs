using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blogger_WebSite.Models
{
    public class Projects
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [StringLength(50)]
        public string Images { get; set; }

        [StringLength(50)]
        public string ProjectName { get; set; }

        [StringLength(100)]
        public string ProjectURL { get; set; }

        public int UseId { get; set; }

        public Users Users { get; set; }

    }
}
