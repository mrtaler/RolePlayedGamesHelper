namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class AttributeBonus
    {
        public int Id { get; set; }
        public int? FkSkill { get; set; }
        public int? FkAmount { get; set; }
        public string AttributeLimitation { get; set; }
        public string AttributeValue { get; set; }
        public string AmountPerLevel { get; set; }
        public string AmountValue { get; set; }
        public int? FkAdvantage { get; set; }

        public virtual Advantage FkAdvantageNavigation { get; set; }
        public virtual GurpsSkill FkSkillNavigation { get; set; }
    }
}
