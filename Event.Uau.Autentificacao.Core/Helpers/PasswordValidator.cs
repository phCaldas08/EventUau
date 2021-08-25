using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Event.Uau.Autenticacao.Core.Helpers
{
    public static class PasswordValidator
    {
        public static string Rule
        {
            get => $"A senha deve {string.Join(", ", regras.Select(i => i.Description))}.";
        }

        private static readonly List<PassawordRule> regras = new List<PassawordRule> {
            new PassawordRule("ter entre 8 e 15 caracteres", password => password.Length >= 8 && password.Length <= 15),
            new PassawordRule("um número",                   password => Regex.IsMatch(password, @"\d+")),
            new PassawordRule("uma letra minúscula",         password => Regex.IsMatch(password, @"[a-z]")),
            new PassawordRule("uma letra maiúscula",         password => Regex.IsMatch(password, @"[A-Z]")),
            new PassawordRule("um caracter especial",        password => Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]"))
        };

        public static bool CanBeUsed(this string password) =>
            regras.All(i => i.Rule.Invoke(password));


        private class PassawordRule
        {
            public string Description { get; set; }
            public Func<string, bool> Rule { get; set; }

            public PassawordRule(string description, Func<string, bool> rule)
            {
                Description = description;
                Rule = rule;
            }
        }
    }
}
