using System;
namespace Event.Uau.Avaliacao.Domain.Entities
{
    public class Rating
    {
        public long Id { get; set; }
        public long IdUserEmployee { get; set; }
        public long IdUserEmployer { get; set; }

        public int Stars { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; } 
    }
}
