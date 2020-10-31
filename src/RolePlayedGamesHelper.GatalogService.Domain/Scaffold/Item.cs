using System;
using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Item
    {
        public Item()
        {
            AvailableAttachSlot = new HashSet<AvailableAttachSlot>();
            BoxItem = new HashSet<BoxItem>();
            InventoryOfChar = new HashSet<InventoryOfChar>();
        }

        public int UiIndex { get; set; }
        public string SzItemName { get; set; }
        public string SzLongItemName { get; set; }
        public string SzItemDesc { get; set; }
        public int UsItemClass { get; set; }
        public int UbClassIndex { get; set; }
        public decimal UbWeight { get; set; }
        public string ItemSize { get; set; }
        public decimal UsPrice { get; set; }
        public bool Damageable { get; set; }
        public bool Repairable { get; set; }
        public bool WaterDamages { get; set; }
        public bool Metal { get; set; }
        public bool TwoHanded { get; set; }
        public bool Electronic { get; set; }
        public bool Ht { get; set; }
        public bool Ut { get; set; }
        public bool NeedsBatteries { get; set; }
        public bool HaveFingerPrintId { get; set; }
        public int Tl { get; set; }
        public int Lc { get; set; }
        public string SizeBatteries { get; set; }
        public decimal? LockPickModifier { get; set; }
        public decimal? CrowbarModifier { get; set; }
        public decimal? DisarmModifier { get; set; }
        public decimal? RepairModifier { get; set; }
        public decimal? DamageChance { get; set; }
        public byte[] ItemImage { get; set; }
        public int MinSt { get; set; }
        public string Link { get; set; }
        public bool Used { get; set; }
        public DateTime? Dt { get; set; }
        public int CountOfBat { get; set; }
        public string WorksOnBat { get; set; }

        public virtual LegalityClass LegalityClassNavigation { get; set; }
        public virtual TechnicalLevel TechnicalLevelNavigation { get; set; }
        public virtual ItemSubClass UsItemClassNavigation { get; set; }
     //   public virtual Armour Armour { get; set; }
        public virtual Attachment Attachment { get; set; }
        public virtual Clothes Clothes { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual Explosive Explosive { get; set; }
        public virtual Food Food { get; set; }
        public virtual LoadBearingEquipment LoadBearingEquipment { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual ICollection<AvailableAttachSlot> AvailableAttachSlot { get; set; }
        public virtual ICollection<BoxItem> BoxItem { get; set; }
        public virtual ICollection<InventoryOfChar> InventoryOfChar { get; set; }
    }
}
