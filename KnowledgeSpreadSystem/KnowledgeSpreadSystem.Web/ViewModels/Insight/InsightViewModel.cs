using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowledgeSpreadSystem.Web.ViewModels.Insight
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class InsightViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        [MaxLength(500)]
        public string Content { get; set; }

        public string AuthorId { get; set; }
    }
}