namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class DrBonusDb
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string PerLevel { get; set; }
        public string Value { get; set; }
        public int? IdAdv { get; set; }

        public virtual Advantage IdAdvNavigation { get; set; }
    }
}
