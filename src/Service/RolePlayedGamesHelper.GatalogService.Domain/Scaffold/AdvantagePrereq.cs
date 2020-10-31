namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class AdvantagePrereq
    {
        public int Id { get; set; }
        public string NameCompare { get; set; }
        public string Name { get; set; }
        public string NotesCompare { get; set; }
        public string Notes { get; set; }
        public string LevelCompare { get; set; }
        public string Level { get; set; }
        public string Has { get; set; }
        public int? IdPrqList { get; set; }
        public string Value { get; set; }

        public virtual PrereqListDb IdPrqListNavigation { get; set; }
    }
}
