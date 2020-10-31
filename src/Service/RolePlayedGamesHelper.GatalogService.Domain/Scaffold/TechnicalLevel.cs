using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class TechnicalLevel
    {
        public TechnicalLevel()
        {
            GurpsSkill = new HashSet<GurpsSkill>();
            Item = new HashSet<Item>();
        }

        public int IdTl { get; set; }
        public string NameTl { get; set; }
        public string Description { get; set; }
        public decimal StartMoney { get; set; }

        public virtual ICollection<GurpsSkill> GurpsSkill { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
