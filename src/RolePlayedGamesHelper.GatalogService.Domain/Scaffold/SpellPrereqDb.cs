namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class SpellPrereqDb
    {
        public int Id { get; set; }
        public string NameCompare { get; set; }
        public string Name { get; set; }
        public string CollegeCompare { get; set; }
        public string College { get; set; }
        public string CollegeCountCompare { get; set; }
        public string CollegeCount { get; set; }
        public string QuantityCompare { get; set; }
        public string Quantity { get; set; }
        public string Anyt { get; set; }
        public string Has { get; set; }
        public int? IdPrqlist { get; set; }
        public string Value { get; set; }

        public virtual PrereqListDb IdPrqlistNavigation { get; set; }
    }
}
