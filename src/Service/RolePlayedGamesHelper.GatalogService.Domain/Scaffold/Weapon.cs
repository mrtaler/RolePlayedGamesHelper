using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Weapon
    {
        public Weapon()
        {
            WeaponDamage = new HashSet<WeaponDamage>();
        }

        public int UiIndex { get; set; }
        public int? CaliberId { get; set; }
        public int DefAcc { get; set; }
        public int? AccAddin { get; set; }
        public decimal HalfRange { get; set; }
        public decimal FullRange { get; set; }
        public bool MinRange { get; set; }
        public decimal Aweight { get; set; }
        public int Rof { get; set; }
        public bool FullAuto { get; set; }
        public int? RofForSh { get; set; }
        public int Shots { get; set; }
        public int TimeForReload { get; set; }
        public bool SingleReload { get; set; }
        public int Recoil { get; set; }
        public bool HeavyWeapon { get; set; }
        public bool AddInChamber { get; set; }
        public bool CutOffShots { get; set; }
        public int CutOffShotsCount { get; set; }
        public bool GrenadeLauncher { get; set; }
        public bool RocketLauncher { get; set; }
        public bool Mortar { get; set; }
        public bool Cannon { get; set; }
        public bool SingleShotRocketLauncher { get; set; }
        public bool RocketRifle { get; set; }
        public bool Bulkfolded { get; set; }
        public bool Hcrof { get; set; }
        public int HcrofValue { get; set; }

        public virtual Caliber Caliber { get; set; }
        public virtual Item UiIndexNavigation { get; set; }
        public virtual ICollection<WeaponDamage> WeaponDamage { get; set; }
    }
}
