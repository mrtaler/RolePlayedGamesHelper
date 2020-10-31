namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class AdvantageCategory88
    {
        public int IdAdvantage { get; set; }
        public int IdGurpsCategory { get; set; }

        public virtual Advantage IdAdvantageNavigation { get; set; }
        public virtual GurpsCategory IdGurpsCategoryNavigation { get; set; }
    }
}
