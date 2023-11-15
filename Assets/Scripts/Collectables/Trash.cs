public class Trash : Collectable
{
    public override void Collect(Player player)
    {
        player.Lose();
        Destroy(gameObject);
    }
}
