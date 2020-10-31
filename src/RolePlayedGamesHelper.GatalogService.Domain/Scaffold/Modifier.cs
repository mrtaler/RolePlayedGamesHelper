namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Modifier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameC { get; set; }
        public string Notes { get; set; }
        public string NotesC { get; set; }
        public string Levels { get; set; }
        public string Reference { get; set; }
        public string Affects { get; set; }
        public string Version { get; set; }
        public string Enabled { get; set; }
        public int? IdAdv { get; set; }
        public string Cost { get; set; }
        public string CostType { get; set; }

        public virtual Advantage IdAdvNavigation { get; set; }
    }
}
