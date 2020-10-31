using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class AttachmentSlot
    {
        public AttachmentSlot()
        {
            AttachmentMount = new HashSet<AttachmentMount>();
            GsubAttachClass = new HashSet<GsubAttachClass>();
        }

        public int Id { get; set; }
        public string AttachmentSlotName { get; set; }

        public virtual ICollection<AttachmentMount> AttachmentMount { get; set; }
        public virtual ICollection<GsubAttachClass> GsubAttachClass { get; set; }
    }
}
