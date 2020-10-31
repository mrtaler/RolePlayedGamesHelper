using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class ItemSubClass
    {
        public ItemSubClass()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string NameSub { get; set; }
        public int IdItemClass { get; set; }
        public string Type { get; set; }
        public int? IdGurpsSubClass { get; set; }

        public virtual GurpsClass IdGurpsSubClassNavigation { get; set; }
        public virtual ItemClass IdItemClassNavigation { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
