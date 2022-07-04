using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoronaProject.Models
{
    public class Certificate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public int VisitorId { get; set; }
        [MaxLength(10)]
        public string FileExtension { get; set; }
        public byte[] File { get; set; }

    }
}
