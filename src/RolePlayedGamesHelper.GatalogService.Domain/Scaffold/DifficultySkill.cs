using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class DifficultySkill
    {
        public DifficultySkill()
        {
            GurpsSkill = new HashSet<GurpsSkill>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string BaseCost { get; set; }

        public virtual ICollection<GurpsSkill> GurpsSkill { get; set; }
    }
}
