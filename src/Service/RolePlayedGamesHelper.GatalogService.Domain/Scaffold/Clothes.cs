namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Clothes
    {
        public int UiIndex { get; set; }
        public string ComfortTemperature { get; set; }
        public string Wearout { get; set; }

        public virtual Item UiIndexNavigation { get; set; }
    }
}
