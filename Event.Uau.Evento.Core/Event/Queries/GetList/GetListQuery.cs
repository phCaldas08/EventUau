using System;
using System.Collections;
using System.Collections.Generic;
using MediatR;

namespace Event.Uau.Evento.Core.Event.Queries.GetList
{
    public class GetListQuery : IRequest<IEnumerable<Domain.Entities.Event>>
    {
        public string textSearch { get; set; } = string.Empty;
        public int? Index { get; set; } = 0;
        public int? PageSize { get; set; } = 20;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
