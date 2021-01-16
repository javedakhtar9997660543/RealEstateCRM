using System.Diagnostics.CodeAnalysis;

namespace AdminProject.PersistenceLayer.Entities.Model
{
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

}
