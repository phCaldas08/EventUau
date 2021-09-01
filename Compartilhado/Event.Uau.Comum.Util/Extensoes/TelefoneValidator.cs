using System;
using System.Text.RegularExpressions;

namespace Event.Uau.Comum.Util.Extensoes
{
    public static class TelefoneValidator
    {
        public static bool TelefoneValido(this string telefone) =>
            Regex.IsMatch(telefone, @"\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}");

        public static string LimparTelefone(this string telefone) =>
            telefone.Replace(" ", string.Empty)
                    .Replace("(", string.Empty)
                    .Replace(")", string.Empty)
                    .Replace("-", string.Empty);
    }
}
