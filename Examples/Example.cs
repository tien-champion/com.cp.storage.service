using UnityEngine;

namespace Champion
{
    public class Example : MonoBehaviour
    {
        private void Awake()
        {
            var storages = Resources.LoadAll<BaseDataSO>("");
            Debug.Log("storages loaded: " + storages.Length);
            foreach (var storage in storages)
            {
                StorageService.Register(storage);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StorageService.Get<PlayerDataTSO>().AddCurrency(new Currency()
                {
                    Qty = UnityEngine.Random.Range(0, int.MaxValue)
                });
            }
        }
    }
}