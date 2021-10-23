using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Event.Uau.Carteira.ViewModel.Carteira
{
    public class CarteiraViewModel
    {
        public List<OperacaoViewModel> Operacoes { get; set; }

        public decimal ValorDisponivel
        {
            get => (OperacoesExecutadas?.Sum(i => (i.Operacoes?.Sum(j => j.Valor)).GetValueOrDefault(0))).GetValueOrDefault(0);
        }

        public decimal ValorFuturo
        {
            get => (OperacoesFuturas?.Sum(i => (i.Operacoes?.Sum(j => j.Valor)).GetValueOrDefault(0))).GetValueOrDefault(0);
        }

        private IEnumerable<TipoOperacaoViewModel> TiposOperacoes { get => Operacoes.Select(i => i.TipoOperacao); }


        [JsonIgnore]
        public IEnumerable<OperacoesPorTipoViewModel> OperacoesExecutadas
        {
            get => Operacoes?.Where(i => i.TipoOperacao.EhDisponivel && i.TipoOperacao.EhVisivel)
                    .GroupBy(i => i.TipoOperacao.Id)
                    .Select(i => new OperacoesPorTipoViewModel { TipoOperacao = TiposOperacoes.FirstOrDefault(t => t.Id == i.Key), Operacoes = i.ToList() });
            
        }

        [JsonIgnore]
        public IEnumerable<OperacoesPorTipoViewModel> OperacoesFuturas
        {
            get => Operacoes?.Where(i => !i.TipoOperacao.EhDisponivel && i.TipoOperacao.EhVisivel)
                    .GroupBy(i => i.TipoOperacao.Id)
                    .Select(i => new OperacoesPorTipoViewModel { TipoOperacao = TiposOperacoes.FirstOrDefault(t => t.Id == i.Key), Operacoes = i.ToList() });

        }
    }
}
