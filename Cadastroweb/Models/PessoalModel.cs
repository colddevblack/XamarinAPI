using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cadastroweb.Models
{
    public class PessoalModel
    {
        [Key]
        public int Id { get; set; }
        public string atividade { get; set; }
        public string descricao { get; set; }

    }
}