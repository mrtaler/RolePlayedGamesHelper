namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class InventoryOfChar
    {
        public int Id { get; set; }
        public int IdCharacter { get; set; }
        public int IdItem { get; set; }
        public long Count { get; set; }

        public virtual CharacterDb IdCharacterNavigation { get; set; }
        public virtual Item IdItemNavigation { get; set; }
    }
}
