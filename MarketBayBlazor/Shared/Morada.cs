using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketBayBlazor.Shared
{
    [Table("Morada")]
    public class Morada
    {

        [Key]
        public int ID { get;set; }
        [MaxLength(200)]
        public string Rua { get; set; }
        [MaxLength(8)]
        public string CodigoPostal { get; set; }
        [MaxLength(100)]
        public string Localidade { get; set; }

    }
}

