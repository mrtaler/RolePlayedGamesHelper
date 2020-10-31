namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class WeaponDamage
    {
        public int Id { get; set; }
        public int IdWeapon { get; set; }
        public int IdWeaponAttackType { get; set; }
        public string Damage { get; set; }
        public decimal ArmorDivision { get; set; }
        public int? IdTypeOfDamage1 { get; set; }
        public int? IdTypeOfDamage2 { get; set; }
        public string TypeOfDamage1Text { get; set; }
        public string TypeOfDamage2Text { get; set; }
        public string Descrip { get; set; }

        public virtual TypeOfDamage IdTypeOfDamage1Navigation { get; set; }
        public virtual TypeOfDamage IdTypeOfDamage2Navigation { get; set; }
        public virtual WeaponAttackType IdWeaponAttackTypeNavigation { get; set; }
        public virtual Weapon IdWeaponNavigation { get; set; }
    }
}
