using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.ViewModels.Rating
{
    public class TotalRatingViewModel
    {
        public string TargetId { get; set; }

        public int RatingsCount { get; set; }

        public double Rating { get; set; }
    }
}