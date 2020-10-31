namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class SkillPrereqDb
    {
        public int Id { get; set; }
        public string NameCompare { get; set; }
        public string Name { get; set; }
        public string SpecializationCompare { get; set; }
        public string Specialization { get; set; }
        public string LevelSpCompare { get; set; }
        public string LevelSp { get; set; }
        public string Has { get; set; }
        public int? IdprereqList { get; set; }

        public virtual PrereqListDb IdprereqListNavigation { get; set; }
    }
}
