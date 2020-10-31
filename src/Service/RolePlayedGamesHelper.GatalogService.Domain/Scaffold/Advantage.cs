using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Advantage
    {
        public Advantage()
        {
            AdvantageCategory88 = new HashSet<AdvantageCategory88>();
            AttributeBonus = new HashSet<AttributeBonus>();
            CostReduction = new HashSet<CostReduction>();
            DrBonusDb = new HashSet<DrBonusDb>();
            MeleeWeapon = new HashSet<MeleeWeapon>();
            Modifier = new HashSet<Modifier>();
            PrereqListDb = new HashSet<PrereqListDb>();
            RangedWeapon = new HashSet<RangedWeapon>();
            SkillBonusDb = new HashSet<SkillBonusDb>();
            SpellBonus = new HashSet<SpellBonus>();
            WeaponBonus = new HashSet<WeaponBonus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCompare { get; set; }
        public string Typeadc { get; set; }
        public string Levels { get; set; }
        public string PointsPerLevel { get; set; }
        public string BasePoints { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string Cr { get; set; }
        public string Versionadv { get; set; }
        public string RoundDown { get; set; }

        public virtual ICollection<AdvantageCategory88> AdvantageCategory88 { get; set; }
        public virtual ICollection<AttributeBonus> AttributeBonus { get; set; }
        public virtual ICollection<CostReduction> CostReduction { get; set; }
        public virtual ICollection<DrBonusDb> DrBonusDb { get; set; }
        public virtual ICollection<MeleeWeapon> MeleeWeapon { get; set; }
        public virtual ICollection<Modifier> Modifier { get; set; }
        public virtual ICollection<PrereqListDb> PrereqListDb { get; set; }
        public virtual ICollection<RangedWeapon> RangedWeapon { get; set; }
        public virtual ICollection<SkillBonusDb> SkillBonusDb { get; set; }
        public virtual ICollection<SpellBonus> SpellBonus { get; set; }
        public virtual ICollection<WeaponBonus> WeaponBonus { get; set; }
    }
}
