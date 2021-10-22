using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Uau.Endereco.Infrastructure.Cep.Models.Retorno
{
    public class EnderecoRetornoModel
    {
        public int status { get; set; }
        public bool ok { get; set; }
        public string code { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string statusText { get; set; }
    }
}
