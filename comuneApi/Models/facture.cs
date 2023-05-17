using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace comuneApi.Models
{
    public class facture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Num_facture { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string Designation { get; set; } = string.Empty;
        public DateTime? Date_facture { get; set; }


        [ForeignKey("FournisseurId")]
        public Guid? FournisseurId { get; set; }
        //public fournisseur Fournisseur { get; set; }
       

    }
}
