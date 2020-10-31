using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class ItemClass
    {
        public ItemClass()
        {
            ItemSubClass = new HashSet<ItemSubClass>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ItemSubClass> ItemSubClass { get; set; }
    }
}
