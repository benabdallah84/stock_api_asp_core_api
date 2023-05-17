using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comuneApi.Models
{
    public class operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string titre { get; set; } = string.Empty;
        public DateTime? Date { get; set; } = default;

        [ForeignKey("beneficieId")]
        public Guid? beneficieId { get; set; }
       //public beneficie beneficie { get; set; }
    }
}
