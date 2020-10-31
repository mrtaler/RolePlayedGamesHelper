using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class RangedWeapon
    {
        public RangedWeapon()
        {
            DefSkillSome = new HashSet<DefSkillSome>();
        }

        public int Id { get; set; }
        public string Damage { get; set; }
        public string Strength { get; set; }
        public string Usage { get; set; }
        public string Accuracy { get; set; }
        public string Range { get; set; }
        public string RateOfFire { get; set; }
        public string Recoil { get; set; }
        public string Shots { get; set; }
        public string Bulk { get; set; }
        public int? IdAdv { get; set; }

        public virtual Advantage IdAdvNavigation { get; set; }
        public virtual ICollection<DefSkillSome> DefSkillSome { get; set; }
    }
}
