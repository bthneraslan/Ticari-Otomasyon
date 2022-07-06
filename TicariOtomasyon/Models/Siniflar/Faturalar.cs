﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Faturalar
    {
        [Key]
        public int FaturaID { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturSeriNo { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(6)]
        public string FaturSıraNo { get; set; }
        public DateTime Tarih { get; set; }
        [Column(TypeName = "Char")]
        [StringLength(5)]
        public string Saat { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string VergiDairesi { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }


        public decimal Toplam { get; set; }
        public virtual ICollection<FaturaKalem> FaturaKalems { get; set; }
    }
}