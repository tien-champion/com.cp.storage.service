namespace Champion
{
    [System.Serializable]
    public enum CurrencyType
    {
        Coin,
        Diamond
    }

    [System.Serializable]
    public class Currency
    {
        public CurrencyType Type;
        public int Qty;
    }
}