using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {

        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(70)]
        public string Alıcı { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(70)]
        public string Gonderen { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(50)]
        public string Konu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(3000)]
        public string Icerik { get; set; }

        [Column(TypeName = "Smalldatetime")]
        public DateTime Tarih { get; set; }
    }
}