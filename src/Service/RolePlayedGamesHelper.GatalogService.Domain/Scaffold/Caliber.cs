using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Caliber
    {
        public Caliber()
        {
            Weapon = new HashSet<Weapon>();
        }

        public int Id { get; set; }
        public string CaliberName { get; set; }
        public string AltCaliberName { get; set; }
        public string ClassOfCaliber { get; set; }
        public decimal? DimOfBulletSi { get; set; }
        public decimal? DimOfBulletUs { get; set; }

        public virtual ICollection<Weapon> Weapon { get; set; }
    }
}
