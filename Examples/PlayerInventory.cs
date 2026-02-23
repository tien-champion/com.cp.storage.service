using System.Collections.Generic;

namespace Champion
{
    [System.Serializable]
    public class PlayerInventory
    {
        public List<Currency> Currencies;
        public List<Item> Items;
    }
}