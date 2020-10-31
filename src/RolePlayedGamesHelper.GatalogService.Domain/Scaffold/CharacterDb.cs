using System.Collections.Generic;

namespace RolePlayedGamesHelper.GatalogService.Domain.Scaffold
{
    public class CharacterDb
    {
        public CharacterDb()
        {
            CharSkill = new HashSet<CharSkill>();
            InventoryOfChar = new HashSet<InventoryOfChar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StrengthPoints { get; set; }
        public int DexterityPoints { get; set; }
        public int IntelligencePoints { get; set; }
        public int HealthPoints { get; set; }
        public int MaxHppoints { get; set; }
        public int MaxFppoints { get; set; }
        public int PerceptionPoints { get; set; }
        public int WillpowerPoints { get; set; }
        public decimal BasicSpeedPoints { get; set; }
        public int BasicMovePoints { get; set; }

        public virtual ICollection<CharSkill> CharSkill { get; set; }
        public virtual ICollection<InventoryOfChar> InventoryOfChar { get; set; }
    }
}
