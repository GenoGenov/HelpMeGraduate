namespace KnowledgeSpreadSystem.Web.ViewModels.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Data.Common.Models;

    public class BaseViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
    }
}