namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdminViewModel
    {
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime? ModifiedOn { get; set; }
    }
}