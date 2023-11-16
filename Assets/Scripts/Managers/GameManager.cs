using UnityEngine;
using System.Threading.Tasks;
using TMPro;
using Events;

public class GameManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private int _startGameDelay = 3;

    [Header("Dependcies")]
    [SerializeReference]
    private TMP_Text _counterLabel;
    [SerializeReference]
    private PlayerGlobalData _playerGlobalData;
    [SerializeReference]
    private Player _player;

    public static GameManager instance;

    public void ApplyCollectedCoins()
    {
        _playerGlobalData.CoinCount += _player.CoinManager.Amount;
    }

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }

    private async void Start()
    {
        PauseManager.instance.SetGamePause(true);

        _counterLabel.gameObject.SetActive(true);

        for (int i = 0; i < _startGameDelay; i++) {
            _counterLabel.text = (_startGameDelay - i).ToString();
            await Task.Delay(1000);
        }

        StartGame();
    }

    private void StartGame()
    {
        PauseManager.instance.SetGamePause(false);
        Observer.Post(this, new GameStartEvent { });
        Destroy(_counterLabel.gameObject);
    }
}
