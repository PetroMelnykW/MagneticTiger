public class Coin : Collectable
{
    private const int DefaultCoinValue = 1;

    public override void Collect(Player player)
    {
        player.CoinManager.AddCoins(DefaultCoinValue);
        Destroy(gameObject);
    }
}
