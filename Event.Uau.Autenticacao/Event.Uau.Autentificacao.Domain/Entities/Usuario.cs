﻿using System;
namespace Event.Uau.Autenticacao.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Cpf { get; set; }

        public string Senha { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string SobreMim { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Status { get; set; }

        public virtual Parceiro Parceiro { get; set; }
    }
}
