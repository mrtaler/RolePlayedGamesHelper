namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class CharSkill
    {
        public int IdSkill { get; set; }
        public int IdChar { get; set; }
        public int? PointOfSkill { get; set; }

        public virtual CharacterDb IdCharNavigation { get; set; }
        public virtual GurpsSkill IdSkillNavigation { get; set; }
    }
}
