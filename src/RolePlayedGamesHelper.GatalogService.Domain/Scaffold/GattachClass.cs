using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class GattachClass
    {
        public GattachClass()
        {
            GsubAttachClass = new HashSet<GsubAttachClass>();
        }

        public int Id { get; set; }
        public string NameClass { get; set; }

        public virtual ICollection<GsubAttachClass> GsubAttachClass { get; set; }
    }
}
