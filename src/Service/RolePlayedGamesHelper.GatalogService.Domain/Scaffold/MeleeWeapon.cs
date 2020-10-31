using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class MeleeWeapon
    {
        public MeleeWeapon()
        {
            DefSkillSome = new HashSet<DefSkillSome>();
        }

        public int Id { get; set; }
        public string Damage { get; set; }
        public string Strength { get; set; }
        public string Usage { get; set; }
        public string Reach { get; set; }
        public string Parry { get; set; }
        public string Block { get; set; }
        public int? IdAdv { get; set; }

        public virtual Advantage IdAdvNavigation { get; set; }
        public virtual ICollection<DefSkillSome> DefSkillSome { get; set; }
    }
}
