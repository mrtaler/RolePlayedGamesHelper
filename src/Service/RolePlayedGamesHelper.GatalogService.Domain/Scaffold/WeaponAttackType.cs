using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class WeaponAttackType
    {
        public WeaponAttackType()
        {
            WeaponDamage = new HashSet<WeaponDamage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descr { get; set; }

        public virtual ICollection<WeaponDamage> WeaponDamage { get; set; }
    }
}
