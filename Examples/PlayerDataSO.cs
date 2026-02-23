using UnityEngine;

namespace Champion
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "SO/Data/PlayerData")]
    public class PlayerDataSO : BaseDataSO
    {
        public PlayerProfile Profile;
        public PlayerInventory Inventory;

        public override void Save()
        {
            LocalDataSystem.Save("player-profile", Profile, Encrypt);
            LocalDataSystem.Save("player-inventory", Inventory, Encrypt);
        }

        public override void Load()
        {
            Profile = LocalDataSystem.Load<PlayerProfile>("player-profile", Encrypt);
            Inventory = LocalDataSystem.Load<PlayerInventory>("player-inventory", Encrypt);
        }

        public override void Delete()
        {
            LocalDataSystem.Delete("player-profile");
            LocalDataSystem.Delete("player-inventory");
        }
    }
}