using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class GurpsCategory
    {
        public GurpsCategory()
        {
            AdvantageCategory88 = new HashSet<AdvantageCategory88>();
            GurpsSkillCategory88 = new HashSet<GurpsSkillCategory88>();
        }

        public int Id { get; set; }
        public string NameCategory { get; set; }

        public virtual ICollection<AdvantageCategory88> AdvantageCategory88 { get; set; }
        public virtual ICollection<GurpsSkillCategory88> GurpsSkillCategory88 { get; set; }
    }
}
