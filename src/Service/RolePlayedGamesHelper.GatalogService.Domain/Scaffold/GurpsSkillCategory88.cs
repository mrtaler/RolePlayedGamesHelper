namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class GurpsSkillCategory88
    {
        public int IdSkill { get; set; }
        public int IdSkillCategory { get; set; }

        public virtual GurpsCategory IdSkillCategoryNavigation { get; set; }
        public virtual GurpsSkill IdSkillNavigation { get; set; }
    }
}
