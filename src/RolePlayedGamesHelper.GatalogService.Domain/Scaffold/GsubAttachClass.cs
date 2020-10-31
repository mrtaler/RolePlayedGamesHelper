using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class GsubAttachClass
    {
        public GsubAttachClass()
        {
            GavAttachClass = new HashSet<GavAttachClass>();
        }

        public int Id { get; set; }
        public string SubAttachName { get; set; }
        public int AttachClass { get; set; }
        public string SubAttachDescription { get; set; }
        public int Attachmentslot { get; set; }

        public virtual GattachClass AttachClassNavigation { get; set; }
        public virtual AttachmentSlot AttachmentslotNavigation { get; set; }
        public virtual ICollection<GavAttachClass> GavAttachClass { get; set; }
    }
}
