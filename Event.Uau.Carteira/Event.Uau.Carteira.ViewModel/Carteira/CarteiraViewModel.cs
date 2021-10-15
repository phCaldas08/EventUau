using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Event.Uau.Carteira.ViewModel.Carteira
{
    public class CarteiraViewModel
    {
        [JsonIgnore]
        public List<OperacaoViewModel> Operacoes { get; set; }

        public decimal ValorDisponivel
        {
            get => (OperacoesExecutadas?.Sum(i => (i.Value?.Sum(j => j.Valor)).GetValueOrDefault(0))).GetValueOrDefault(0);
        }

        public decimal ValorFuturo
        {
            get => (OperacoesFuturas?.Sum(i => (i.Value?.Sum(j => j.Valor)).GetValueOrDefault(0))).GetValueOrDefault(0);
        }

        private IEnumerable<TipoOperacaoViewModel> TiposOperacoes { get => Operacoes.Select(i => i.TipoOperacao); }


        public Dictionary<TipoOperacaoViewModel, List<OperacaoViewModel>> OperacoesExecutadas
        {
            get => Operacoes.Where(i => i.TipoOperacao.EhDisponivel)
                    .GroupBy(i => i.TipoOperacao.Id)
                    .ToDictionary(i => TiposOperacoes.FirstOrDefault(t => t.Id == i.Key), i => i.ToList());
            
        }

        public Dictionary<TipoOperacaoViewModel, List<OperacaoViewModel>> OperacoesFuturas
        {
            get => Operacoes.Where(i => !i.TipoOperacao.EhDisponivel)
                    .GroupBy(i => i.TipoOperacao.Id)
                    .ToDictionary(i => TiposOperacoes.FirstOrDefault(t => t.Id == i.Key), i => i.ToList());

        }
    }
}
