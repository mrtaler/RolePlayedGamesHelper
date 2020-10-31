namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
  public class AmmoUpgrades
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AmmoUpgrades"/> class.
    /// </summary>
    public AmmoUpgrades() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="AmmoUpgrades"/> class.
    /// </summary>
    /// <param name="id"> The id. </param>
    /// <param name="name"> The name. </param>
    /// <param name="shortname"> The shortname. </param>
    /// <param name="malf"> The malf. </param>
    /// <param name="arDivX"> The ar div x. </param>
    /// <param name="accAdd"> The acc add. </param>
    /// <param name="accX"> The acc x. </param>
    /// <param name="damageX"> The damage x. </param>
    /// <param name="damType"> The dam type. </param>
    /// <param name="rangeX12"> The range x 12. </param>
    /// <param name="rangeX"> The range x. </param>
    /// <param name="stX"> The st x. </param>
    /// <param name="wpsX"> The wps x. </param>
    /// <param name="cpsX"> The cps x. </param>
    /// <param name="hearing"> The hearing. </param>
    /// <param name="ammoClass"> The ammo class. </param>
    /// <param name="minCaliber"> The min caliber. </param>
    /// <param name="maxCalider"> The max calider. </param>
    /// <param name="dtMinAmmoCAliber"> The dt min ammo c aliber. </param>
    /// <param name="conditionDtMinAmmoCal"> The condition dt min ammo cal. </param>
    /// <param name="hearingTable"> The hearing table. </param>
    /// <param name="upgrates"> The upgrates. </param>
    /// <param name="followUp"> The follow up. </param>
    /// <param name="linked"> The linked. </param>
    public AmmoUpgrades(int id, string name, string shortname, int malf, decimal arDivX, int accAdd, decimal accX, decimal damageX, string damType, decimal rangeX12, decimal rangeX, decimal stX, decimal wpsX, decimal cpsX, int hearing, string ammoClass, decimal? minCaliber, decimal? maxCalider, decimal? dtMinAmmoCAliber, string conditionDtMinAmmoCal, int hearingTable, string upgrates, string followUp, string linked)
    {
      Id                    = id;
      Name                  = name;
      Shortname             = shortname;
      Malf                  = malf;
      ArDivX                = arDivX;
      AccAdd                = accAdd;
      AccX                  = accX;
      DamageX               = damageX;
      DamType               = damType;
      RangeX12              = rangeX12;
      RangeX                = rangeX;
      StX                   = stX;
      WpsX                  = wpsX;
      CpsX                  = cpsX;
      Hearing               = hearing;
      AmmoClass             = ammoClass;
      MinCaliber            = minCaliber;
      MaxCalider            = maxCalider;
      DtMinAmmoCAliber      = dtMinAmmoCAliber;
      ConditionDtMinAmmoCal = conditionDtMinAmmoCal;
      HearingTable          = hearingTable;
      Upgrates              = upgrates;
      FollowUp              = followUp;
      Linked                = linked;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Shortname { get; set; }
    public int Malf { get; set; }
    public decimal ArDivX { get; set; }
    public int AccAdd { get; set; }
    public decimal AccX { get; set; }
    public decimal DamageX { get; set; }
    public string DamType { get; set; }
    public decimal RangeX12 { get; set; }
    public decimal RangeX { get; set; }
    public decimal StX { get; set; }
    public decimal WpsX { get; set; }
    public decimal CpsX { get; set; }
    public int Hearing { get; set; }
    public string AmmoClass { get; set; }
    public decimal? MinCaliber { get; set; }
    public decimal? MaxCalider { get; set; }
    public decimal? DtMinAmmoCAliber { get; set; }
    public string ConditionDtMinAmmoCal { get; set; }
    public int HearingTable { get; set; }
    public string Upgrates { get; set; }
    public string FollowUp { get; set; }
    public string Linked { get; set; }
  }
}