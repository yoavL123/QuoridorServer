using System;
using System.Collections.Generic;

#nullable disable

namespace QuoridorServerBL.Models
{
    public partial class RatingChange
    {
        public int RatingChangeId { get; set; }
        public int RatingChangePlayerId { get; set; }
        public DateTime RatingChangeDate { get; set; }
        public int AlteredRating { get; set; }

        public virtual Player RatingChangePlayer { get; set; }
    }
}
