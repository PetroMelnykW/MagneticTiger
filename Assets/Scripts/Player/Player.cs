using UnityEngine;

public class Player : MonoBehaviour
{
    public event System.Action MovedToNextZone;

    [SerializeField]
    private float _speed = 5f;
    [SerializeField]
    private CoinManager _coinManager;

    public CoinManager CoinManager => _coinManager;
    public Zone CurrentZone { get => _currentZone; private set => _currentZone = value; }

    private Zone _currentZone;

    public void Lose()
    {

    }

    private void Update()
    {
        MoveUp();
    }

    private void MoveUp()
    {
        Vector3 velocity = Vector3.up * _speed * Time.deltaTime;
        transform.position += velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CurrentZone = collision.GetComponent<Zone>();
        MovedToNextZone?.Invoke();
    }
}
