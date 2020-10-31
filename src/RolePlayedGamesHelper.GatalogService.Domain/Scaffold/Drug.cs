namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Drug
    {
        public int UiIndex { get; set; }
        public string Type { get; set; }
        public string Wearout { get; set; }
        public string Addict { get; set; }

        public virtual Item UiIndexNavigation { get; set; }
    }
}
