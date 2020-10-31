using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class TypeOfDamage
    {
        public TypeOfDamage()
        {
            WeaponDamageIdTypeOfDamage1Navigation = new HashSet<WeaponDamage>();
            WeaponDamageIdTypeOfDamage2Navigation = new HashSet<WeaponDamage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LongName { get; set; }
        public string Mdamage { get; set; }

        public virtual ICollection<WeaponDamage> WeaponDamageIdTypeOfDamage1Navigation { get; set; }
        public virtual ICollection<WeaponDamage> WeaponDamageIdTypeOfDamage2Navigation { get; set; }
    }
}
