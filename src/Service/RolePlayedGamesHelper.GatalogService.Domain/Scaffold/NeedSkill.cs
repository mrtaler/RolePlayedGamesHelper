namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class NeedSkill
    {
        public int IdSkillIn { get; set; }
        public int? IdSkillOut { get; set; }
        public string Needed { get; set; }

        public virtual GurpsSkill IdSkillInNavigation { get; set; }
        public virtual GurpsSkill IdSkillOutNavigation { get; set; }
    }
}
