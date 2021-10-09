using System;
namespace Event.Uau.Rating.ViewModel.Rating
{
    public class RatingViewModel
    {
        public long Id { get; set; }
        public long IdUserEmployee { get; set; }
        public long IdUserEmployer { get; set; }

        public int Stars { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }

    }
}
