using UnityEngine;
using TMPro;

[System.Serializable]
public class CoinManager
{
    [Header("Dependencies")]
    [SerializeReference]
    private TextMeshPro _coinLabel;

    private int _amount = 0;

    public void AddCoins(int count)
    {
        _amount += count;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_coinLabel != null) {
            _coinLabel.text = _amount.ToString();
        }
    }
}
