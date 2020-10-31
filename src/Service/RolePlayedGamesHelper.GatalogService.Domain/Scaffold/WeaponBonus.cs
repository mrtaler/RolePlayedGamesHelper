namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class WeaponBonus
    {
        public int Id { get; set; }
        public string NameCompare { get; set; }
        public string Name { get; set; }
        public string SpecializationCompare { get; set; }
        public string Specialization { get; set; }
        public string LevelCompare { get; set; }
        public string Level { get; set; }
        public int? FkSkill { get; set; }
        public string AmountPerLevel { get; set; }
        public string AmountValue { get; set; }
        public int? FkAdv { get; set; }

        public virtual Advantage FkAdvNavigation { get; set; }
        public virtual GurpsSkill FkSkillNavigation { get; set; }
    }
}
