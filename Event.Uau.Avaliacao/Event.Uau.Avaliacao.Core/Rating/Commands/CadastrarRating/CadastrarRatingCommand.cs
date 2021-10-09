using Event.Uau.Comum.Util.Mediator;
using Event.Uau.Rating.ViewModel.Rating;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Uau.Avaliacao.Core.Rating.Commands.CadastrarRating
{
    public class CadastrarRatingCommand : EventUauRequest<RatingViewModel>
    {
        public long Id { get; set; }
        public long IdUserEmployee { get; set; }
        public long IdUserEmployer { get; set; }

        public int Stars { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
