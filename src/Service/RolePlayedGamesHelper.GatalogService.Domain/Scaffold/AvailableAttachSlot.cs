namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class AvailableAttachSlot
    {
        public int Id { get; set; }
        public int RitemId { get; set; }
        public int Rattachmentslot { get; set; }
        public int Rattachmentmount { get; set; }

        public virtual AttachmentMount RattachmentmountNavigation { get; set; }
        public virtual Item Ritem { get; set; }
    }
}
