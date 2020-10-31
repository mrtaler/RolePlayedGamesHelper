namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class DefSkillSome
    {
        public int Id { get; set; }
        public string NameSkill { get; set; }
        public string Specialization { get; set; }
        public string Type { get; set; }
        public string Modifier { get; set; }
        public int? IdSkill { get; set; }
        public int? IdRangeWeap { get; set; }
        public int? IdMeleWeap { get; set; }

        public virtual MeleeWeapon IdMeleWeapNavigation { get; set; }
        public virtual RangedWeapon IdRangeWeapNavigation { get; set; }
        public virtual GurpsSkill IdSkillNavigation { get; set; }
    }
}
