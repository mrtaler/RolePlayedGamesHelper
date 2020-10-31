using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class GurpsSkill
    {
        public GurpsSkill()
        {
            AttributeBonus = new HashSet<AttributeBonus>();
            CharSkill = new HashSet<CharSkill>();
            DefSkillSome = new HashSet<DefSkillSome>();
            DefaultSkillIdSkillInNavigation = new HashSet<DefaultSkill>();
            DefaultSkillIdSkillOutNavigation = new HashSet<DefaultSkill>();
            GurpsSkillCategory88 = new HashSet<GurpsSkillCategory88>();
            InverseIdSpecializationNavigation = new HashSet<GurpsSkill>();
            NeedSkillIdSkillOutNavigation = new HashSet<NeedSkill>();
            PrereqListDb = new HashSet<PrereqListDb>();
            WeaponBonus = new HashSet<WeaponBonus>();
        }

        public int Id { get; set; }
        public string NameSkill { get; set; }
        public string Specialization { get; set; }
        public string Difficulty { get; set; }
        public int? Points { get; set; }
        public string Reference { get; set; }
        public bool? TypeSpecialization { get; set; }
        public int? DefaultModifier { get; set; }
        public string Version { get; set; }
        public string EncumbrancePenaltyMultiplier { get; set; }
        public string Notes { get; set; }
        public int? IdDifficulty { get; set; }
        public int? IdSpecialization { get; set; }
        public int? IdtechLevel { get; set; }
        public string LimitT { get; set; }
        public string TypeSkTh { get; set; }

        public virtual DifficultySkill IdDifficultyNavigation { get; set; }
        public virtual GurpsSkill IdSpecializationNavigation { get; set; }
        public virtual TechnicalLevel IdtechLevelNavigation { get; set; }
        public virtual NeedSkill NeedSkillIdSkillInNavigation { get; set; }
        public virtual ICollection<AttributeBonus> AttributeBonus { get; set; }
        public virtual ICollection<CharSkill> CharSkill { get; set; }
        public virtual ICollection<DefSkillSome> DefSkillSome { get; set; }
        public virtual ICollection<DefaultSkill> DefaultSkillIdSkillInNavigation { get; set; }
        public virtual ICollection<DefaultSkill> DefaultSkillIdSkillOutNavigation { get; set; }
        public virtual ICollection<GurpsSkillCategory88> GurpsSkillCategory88 { get; set; }
        public virtual ICollection<GurpsSkill> InverseIdSpecializationNavigation { get; set; }
        public virtual ICollection<NeedSkill> NeedSkillIdSkillOutNavigation { get; set; }
        public virtual ICollection<PrereqListDb> PrereqListDb { get; set; }
        public virtual ICollection<WeaponBonus> WeaponBonus { get; set; }
    }
}
