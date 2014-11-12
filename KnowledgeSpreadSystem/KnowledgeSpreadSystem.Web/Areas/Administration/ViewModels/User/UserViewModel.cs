namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using KnowledgeSpreadSystem.Models;
    using KnowledgeSpreadSystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
        }
    }
}