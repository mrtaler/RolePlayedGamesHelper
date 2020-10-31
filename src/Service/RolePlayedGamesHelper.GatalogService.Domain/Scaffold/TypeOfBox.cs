using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class TypeOfBox
    {
        public TypeOfBox()
        {
            AnyBoxNameType = new HashSet<AnyBoxNameType>();
        }

        public int Id { get; set; }
        public string NameOfType { get; set; }

        public virtual ICollection<AnyBoxNameType> AnyBoxNameType { get; set; }
    }
}
