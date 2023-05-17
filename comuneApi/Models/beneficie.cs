using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace comuneApi.Models
{
    public class beneficie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Post { get; set; } = string.Empty;

    }

}
