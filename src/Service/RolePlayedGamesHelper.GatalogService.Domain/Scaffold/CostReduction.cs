namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class CostReduction
    {
        public int Id { get; set; }
        public string Attribute { get; set; }
        public string Percentage { get; set; }
        public int? IdAdv { get; set; }

        public virtual Advantage IdAdvNavigation { get; set; }
    }
}
