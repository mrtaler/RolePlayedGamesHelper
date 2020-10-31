using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class AnyBoxNameType
    {
        public AnyBoxNameType()
        {
            BoxItem = new HashSet<BoxItem>();
            InverseParentBoxNameNavigation = new HashSet<AnyBoxNameType>();
        }

        public int Id { get; set; }
        public bool IsSelected { get; set; }
        public string NameOfBox { get; set; }
        public int TypeOfBoxes { get; set; }
        public int? ParentBoxName { get; set; }

        public virtual AnyBoxNameType ParentBoxNameNavigation { get; set; }
        public virtual TypeOfBox TypeOfBoxesNavigation { get; set; }
        public virtual ICollection<BoxItem> BoxItem { get; set; }
        public virtual ICollection<AnyBoxNameType> InverseParentBoxNameNavigation { get; set; }
    }
}
