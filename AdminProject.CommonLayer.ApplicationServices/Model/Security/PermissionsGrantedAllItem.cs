using System.Diagnostics.CodeAnalysis;

namespace AdminProject.CommonLayer.Application.Model.Security
{
    public class PermissionsGrantedAllItem
    {
        public int IdentityKey { get; set; }

        public string ObjectTable { get; set; }

        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "integer")]
        public int ObjectIntegerKey { get; set; }

        public string ObjectStringKey { get; set; }

        public bool IsMandatory { get; set; }

        public bool CanSelect { get; set; }

        public bool CanInsert { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public bool CanExecute { get; set; }
    }

    public class PermissionsGrantedItem
    {
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId = "integer")]
        public int ObjectIntegerKey { get; set; }

        public string ObjectStringKey { get; set; }

        public bool IsMandatory { get; set; }

        public bool CanSelect { get; set; }

        public bool CanInsert { get; set; }

        public bool CanUpdate { get; set; }

        public bool CanDelete { get; set; }

        public bool CanExecute { get; set; }
    }

    public class TopicSecurity
    {
        public int TopicKey { get; set; }
        public bool IsAvailable { get; set; }
    }
}
