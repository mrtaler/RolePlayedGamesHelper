namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class Explosive
    {
        public int UiIndex { get; set; }
        public int UbType { get; set; }
        public int UbDamage { get; set; }
        public int UbStunDamage { get; set; }
        public int UbRadius { get; set; }
        public int UbDuration { get; set; }
        public int UbStartRadius { get; set; }
        public int UbMagSize { get; set; }
        public int UsNumFragments { get; set; }
        public int UbFragType { get; set; }
        public int UbFragDamage { get; set; }
        public int UbFragRange { get; set; }
        public int UbHorizontalDegree { get; set; }
        public int UbVerticalDegree { get; set; }
        public decimal BindoorModifier { get; set; }
        public bool FexplodeOnImpact { get; set; }
        public bool GlGrenade { get; set; }
        public bool RlGrenade { get; set; }
        public bool Mine { get; set; }
        public bool Flare { get; set; }
        public bool Directional { get; set; }
        public bool ShapedCharge { get; set; }

        public virtual Item UiIndexNavigation { get; set; }
    }
}
