using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace comuneApi.Models
{
    public class product
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Matricul { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Designation { get; set; } = string.Empty;
        
        public int Quantity { get; set; }

        [Required]
        public Type productType { get; set; } = Type.Consomable;

        [Column(TypeName = "varchar(100)")]
        public float Prix_unitaire { get; set; }

        public string Note { get; set; }

        [ForeignKey("facturesId")]
        public Guid? facturesId { get; set; }       
        //public facture factures { get; set; }


        [ForeignKey("beneficieId")]
        public Guid? beneficieId { get; set; }
        //public beneficie beneficie { get; set; }


        [ForeignKey("operationId")]
        public Guid? operationId { get; set; }
        //public operation operation { get; set; }
    }
}
