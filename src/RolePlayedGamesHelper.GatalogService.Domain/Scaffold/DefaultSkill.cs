namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class DefaultSkill
    {
        public int Id { get; set; }
        public int IdSkillIn { get; set; }
        public int? IdSkillOut { get; set; }
        public int? Modifier { get; set; }
        public string Type { get; set; }

        public virtual GurpsSkill IdSkillInNavigation { get; set; }
        public virtual GurpsSkill IdSkillOutNavigation { get; set; }
    }
}
