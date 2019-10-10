using Ext.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDTeste.Models
{
    public class Pessoas
    {
        [Display(Name = "ID")]
        public int PES_ID { get; set; }

        [Required(ErrorMessage = "Insira o Nome")]
        [Display(Name = "NOME")]
        public string PES_NOME { get; set; }

        [Required(ErrorMessage = "Insira o CPF")]
        [Display(Name = "CPF")]
        public string PES_CPF { get; set; }

        [Required(ErrorMessage = "Insira a data de nascimento")]
        [Display(Name = "DATA DE NASCIMENTO")]
        public string PES_DT_NASCIMENTO { get; set; }
    }
}