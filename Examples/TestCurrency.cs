namespace Champion
{
    [System.Serializable]
    public enum CurrencyType
    {
        Coin,
        Diamond
    }

    [System.Serializable]
    public class TestCurrency
    {
        public CurrencyType Type;
        public int Qty;
    }
}