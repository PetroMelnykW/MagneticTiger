using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIManager : MonoBehaviour
{
    [SerializeReference]
    private PlayerGlobalData _playerGlobalData;
    [SerializeReference]
    private Button _startButton;
    [SerializeReference]
    private TMP_Text _coinCountLabel;

    private void Awake()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);
        _coinCountLabel.text = _playerGlobalData.CoinCount.ToString();
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
