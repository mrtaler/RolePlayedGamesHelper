using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Attachment
    {
        public Attachment()
        {
            GavAttachClass = new HashSet<GavAttachClass>();
        }

        public int UiIndex { get; set; }
        public int RattachmentClass { get; set; }
        public string Attachmentmount { get; set; }
        public bool HiddenAttachment { get; set; }
        public int? NoiseReduction { get; set; }
        public bool HideMuzzleFlash { get; set; }
        public int? RangeBonus { get; set; }
        public int? AimBonus { get; set; }
        public int? MinRangeForAimBonus { get; set; }
        public int? MagSizeBonus { get; set; }
        public int? BurstSizeBonus { get; set; }
        public int? RateOfFireBonus { get; set; }
        public int? DamageBonus { get; set; }
        public decimal? ScopeMagFactor { get; set; }
        public int? HearingRangeBonus { get; set; }
        public int? VisionRangeBonus { get; set; }
        public int? NightVisionRangeBonus { get; set; }
        public int? DayVisionRangeBonus { get; set; }
        public int? CaveVisionRangeBonus { get; set; }
        public int? BrightLightVisionRangeBonus { get; set; }
        public int? PercentTunnelVision { get; set; }
        public int? FlashLightRange { get; set; }
        public int? RecoilModifier { get; set; }
        public int GsubAttachClass { get; set; }
        public int GattachClass { get; set; }
        public int? Darkness { get; set; }
        public int? BulkAdd { get; set; }
        public bool Fix { get; set; }
        public int? BatTimeWork { get; set; }
        public bool Tritium { get; set; }
        public int? ScopeMagMin { get; set; }
        public int? ScopeMagMax { get; set; }
        public int? AccAddmax { get; set; }
        public int IdAttachmentmount { get; set; }
        public bool ImpVisSights { get; set; }
        public bool BlockIronSight { get; set; }
        public bool Collimator { get; set; }
        public bool Reflex { get; set; }
        public bool Targetingprogram { get; set; }
        public bool Laserrangefinder { get; set; }
        public int? LaserRfrange { get; set; }
        public int? LaserRfAcc { get; set; }
        public int? NightVision { get; set; }
        public bool NeedIrillumination { get; set; }
        public bool Infravision { get; set; }
        public bool IrFilter { get; set; }
        public int? LightRange { get; set; }
        public int? IrLigRange { get; set; }
        public int? LaserRange { get; set; }
        public string LaserColor { get; set; }
        public decimal? LaserColorEf { get; set; }
        public int? UsedBatType { get; set; }

        public virtual AttachmentMount IdAttachmentmountNavigation { get; set; }
        public virtual Item UiIndexNavigation { get; set; }
        public virtual ICollection<GavAttachClass> GavAttachClass { get; set; }
    }
}
