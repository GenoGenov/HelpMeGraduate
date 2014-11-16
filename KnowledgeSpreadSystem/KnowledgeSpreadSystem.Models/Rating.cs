using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeSpreadSystem.Models
{
    using KnowledgeSpreadSystem.Data.Common.Models;
    using KnowledgeSpreadSystem.Models.Base.ResourceEntity;

    class Rating:AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public User Author { get; set; }

        public ResourceEntity Target { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
