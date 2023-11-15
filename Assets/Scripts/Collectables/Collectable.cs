using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
    private const float MinimumCollectionDistance = 0.1f;

    public void Attract(Vector3 playerPosition, float attractionSpeed)
    {
        Vector3 direction = (playerPosition - transform.position).normalized;

        transform.position = transform.position + direction * attractionSpeed;
    }

    public bool CheckIsNear(Vector3 playerPosition)
    {
        return Vector3.Distance(transform.position, playerPosition) < MinimumCollectionDistance;
    }

    public abstract void Collect(Player player);
}
