using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class AttachmentMount
    {
        public AttachmentMount()
        {
            Attachment = new HashSet<Attachment>();
            AvailableAttachSlot = new HashSet<AvailableAttachSlot>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int IdAttacClass { get; set; }

        public virtual AttachmentSlot IdAttacClassNavigation { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<AvailableAttachSlot> AvailableAttachSlot { get; set; }
    }
}
