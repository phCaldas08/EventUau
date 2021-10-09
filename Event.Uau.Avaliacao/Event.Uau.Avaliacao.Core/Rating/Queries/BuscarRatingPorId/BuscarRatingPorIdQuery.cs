using Event.Uau.Comum.Util.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.Uau.Avaliacao.Core.Rating.Queries.BuscarRatingPorId
{
    public class BuscarRatingPorIdQuery : EventUauRequest<ViewModel.Rating.RatingViewModel>
    {
        public int IdRating { get; set; }
    }
}
