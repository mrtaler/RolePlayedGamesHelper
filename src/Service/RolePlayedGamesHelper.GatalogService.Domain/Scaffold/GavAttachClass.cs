namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class GavAttachClass
    {
        public int IdAttach { get; set; }
        public int IdGsubClass { get; set; }
        public int? IdAttachClass { get; set; }

        public virtual Attachment IdAttachNavigation { get; set; }
        public virtual GsubAttachClass IdGsubClassNavigation { get; set; }
    }
}
