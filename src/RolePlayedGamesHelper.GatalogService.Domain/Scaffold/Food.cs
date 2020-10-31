namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Food
    {
        public int UiIndex { get; set; }
        public string GetEnergy { get; set; }
        public string StorageLife { get; set; }

        public virtual Item UiIndexNavigation { get; set; }
    }
}
