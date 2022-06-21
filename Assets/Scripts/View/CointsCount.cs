using TMPro;

public static class CointsCount
{
    static int CoinCount;
    public static void RenderCoinCount(ref TextMeshProUGUI CoinsText)
    {
        CoinCount++;
        CoinsText.text = CoinCount.ToString();
    }
}