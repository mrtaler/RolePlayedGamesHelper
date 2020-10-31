namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class SkillBonusDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Namecompare { get; set; }
        public string Specialization { get; set; }
        public string Specializationcompare { get; set; }
        public string AmountPerLevel { get; set; }
        public string AmountValue { get; set; }
        public int? FkAdv { get; set; }

        public virtual Advantage FkAdvNavigation { get; set; }
    }
}
