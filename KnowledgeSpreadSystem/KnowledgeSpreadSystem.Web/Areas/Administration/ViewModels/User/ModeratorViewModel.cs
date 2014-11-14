namespace KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.User
{
    using System.ComponentModel.DataAnnotations;

    using KnowledgeSpreadSystem.Web.Areas.Administration.ViewModels.Base;

    public class ModeratorViewModel : UserViewModel
    {
        [UIHint("CourseEditor")]
        public SimpleViewModel Course { get; set; }

        [UIHint("UsersEditor")]
        public SimpleViewModel User { get; set; }

        [UIHint("ModeratorEditor")]
        public SimpleViewModel Moderator { get; set; }

    }
}