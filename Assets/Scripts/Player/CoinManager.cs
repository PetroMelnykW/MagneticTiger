using UnityEngine;
using TMPro;

[System.Serializable]
public class CoinManager
{
    [Header("Dependencies")]
    [SerializeReference]
    private TMP_Text _coinLabel;

    public int Amount => _amount;

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
