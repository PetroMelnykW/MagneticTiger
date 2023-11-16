using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/PlayerGlobalData", fileName = "PlayerGlobalData")]
public class PlayerGlobalData : ScriptableObject
{
    [SerializeField]
    private int _coinCount;

    public int CoinCount { get => _coinCount; set => _coinCount = value; }
}
