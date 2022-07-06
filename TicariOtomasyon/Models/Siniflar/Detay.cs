﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TicariOtomasyon.Models.Siniflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName = "VarChar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(2000)]
        public string UrunBilgi { get; set; }
    }
}