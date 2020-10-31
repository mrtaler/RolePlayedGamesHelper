using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class PrereqListDb
    {
        public PrereqListDb()
        {
            AdvantagePrereq = new HashSet<AdvantagePrereq>();
            AttributePrereq = new HashSet<AttributePrereq>();
            ContainedWeightPrereq = new HashSet<ContainedWeightPrereq>();
            InverseFkPrereqListNavigation = new HashSet<PrereqListDb>();
            SkillPrereqDb = new HashSet<SkillPrereqDb>();
            SpellPrereqDb = new HashSet<SpellPrereqDb>();
        }

        public int Id { get; set; }
        public string All { get; set; }
        public string WhenTlCompare { get; set; }
        public string WhenTl { get; set; }
        public string CollegeCountCompare { get; set; }
        public string CollegeCount { get; set; }
        public int? FkPrereqList { get; set; }
        public int? FkSkill { get; set; }
        public int? FkTechnique { get; set; }
        public int? FkAdvantage { get; set; }

        public virtual Advantage FkAdvantageNavigation { get; set; }
        public virtual PrereqListDb FkPrereqListNavigation { get; set; }
        public virtual GurpsSkill FkSkillNavigation { get; set; }
        public virtual ICollection<AdvantagePrereq> AdvantagePrereq { get; set; }
        public virtual ICollection<AttributePrereq> AttributePrereq { get; set; }
        public virtual ICollection<ContainedWeightPrereq> ContainedWeightPrereq { get; set; }
        public virtual ICollection<PrereqListDb> InverseFkPrereqListNavigation { get; set; }
        public virtual ICollection<SkillPrereqDb> SkillPrereqDb { get; set; }
        public virtual ICollection<SpellPrereqDb> SpellPrereqDb { get; set; }
    }
}
