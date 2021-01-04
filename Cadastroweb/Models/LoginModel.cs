using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cadastroweb.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

    }
}