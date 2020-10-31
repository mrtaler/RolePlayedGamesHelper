using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class LegalityClass
    {
        public LegalityClass()
        {
            Item = new HashSet<Item>();
        }

        public int IdLc { get; set; }
        public string NameLc { get; set; }
        public string ShortDes { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
