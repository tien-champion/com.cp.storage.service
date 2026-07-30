using UnityEngine;

namespace Champion
{
    [CreateAssetMenu(fileName = "DemoData", menuName = "Champion/DemoData")]
    public class DemoDataSO : BaseDataSO
    {
        public TestPlayerProfile Profile;
        public TestPlayerInventory Inventory;

        public override void Save()
        {
            LocalDataSystem.Save("player-profile", Profile, Encrypt);
            LocalDataSystem.Save("player-inventory", Inventory, Encrypt);
        }

        public override void Load()
        {
            Profile = LocalDataSystem.Load<TestPlayerProfile>("player-profile", Encrypt);
            Inventory = LocalDataSystem.Load<TestPlayerInventory>("player-inventory", Encrypt);
        }

        public override void Delete()
        {
            LocalDataSystem.Delete("player-profile");
            LocalDataSystem.Delete("player-inventory");
        }
    }
}