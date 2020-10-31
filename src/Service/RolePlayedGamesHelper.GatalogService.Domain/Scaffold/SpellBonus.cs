namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class SpellBonus
    {
        public int Id { get; set; }
        public string SpellName { get; set; }
        public string SpellNameC { get; set; }
        public string CollegeName { get; set; }
        public string CollegeNameC { get; set; }
        public string AllColleges { get; set; }
        public string AmountperLevel { get; set; }
        public string AmountValue { get; set; }
        public int? IdAdv { get; set; }

        public virtual Advantage IdAdvNavigation { get; set; }
    }
}
