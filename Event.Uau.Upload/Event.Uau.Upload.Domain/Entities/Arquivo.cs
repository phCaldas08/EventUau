using System;
namespace Event.Uau.Upload.Domain.Entities
{
    public class Arquivo
    {
        public string Contexto { get; set; }
        public int IdContexto { get; set; }
        public byte[] Conteudo { get; set; }
        public string Nome { get; set; }
        public string TipoConteudo { get; set; }
        public int IdUsuario { get; set; }
    }
}
