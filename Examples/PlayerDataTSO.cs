using UnityEngine;

namespace Champion
{
    [CreateAssetMenu(fileName = "PlayerDataKey", menuName = "PlayerDataKey")]
    public class PlayerDataTSO : BaseDataTSO<TestPlayerInventory>
    {
        public void AddCurrency(TestCurrency testCurrency)
        {
            if (!this._Data.Currencies.Contains(testCurrency))
            {
                this._Data.Currencies.Add(testCurrency);
                this.Save();
                // Raise event...
            }
        }
    }
}