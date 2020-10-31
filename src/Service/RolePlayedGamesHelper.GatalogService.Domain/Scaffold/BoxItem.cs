namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class BoxItem
    {
        public int Id { get; set; }
        public int BoxName { get; set; }
        public int Items { get; set; }
        public int CountItems { get; set; }

        public virtual AnyBoxNameType BoxNameNavigation { get; set; }
        public virtual Item ItemsNavigation { get; set; }
    }
}
