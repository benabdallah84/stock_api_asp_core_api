using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace comuneApi.Models
{
    public class fournisseur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Designation { get; set; }
        public string RC { get; set; }
        public string MF { get; set; }
        public string NA { get; set; }
        public string Compte { get; set; }
        
    }
}
