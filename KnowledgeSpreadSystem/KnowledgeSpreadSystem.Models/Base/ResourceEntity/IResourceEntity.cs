namespace KnowledgeSpreadSystem.Models.Base.ResourceEntity
{
    public interface IResourceEntity
    {
        CourseModule Module { get; set; }

        int? ModuleId { get; set; }

        Course Course { get; set; }

        int? CourseId { get; set; }

        string AuthorId { get; set; }

        User Author { get; set; }
    }
}
