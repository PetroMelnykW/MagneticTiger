using Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUIManager : MonoBehaviour
{
    [Header("Properties")]
    [SerializeReference]
    private Button _topHomeButton;
    [SerializeReference]
    private Button _pauseButton;
    [SerializeReference]
    private Button _pauseMenuHomeButton;
    [SerializeReference]
    private Button _pauseMenuReplayButton;
    [SerializeReference]
    private Button _pauseMenuSoundButton;
    [SerializeReference]
    private GameObject _pauseWindow;
    [SerializeReference]
    private Button _lostMenuHomeButton;
    [SerializeReference]
    private Button _lostMenuReplayButton;
    [SerializeReference]
    private GameObject _lostWindow;

    private void Awake()
    {
        Observer.Subscribe<GameStartEvent>(OnGameStarted);
        Observer.Subscribe<GameLostEvent>(OnGameLost);
        _pauseButton.interactable = false;
        _topHomeButton.onClick.AddListener(OnHomeButtonClicked);
        _pauseButton.onClick.AddListener(OnPauseButtonClick);
        _pauseMenuHomeButton.onClick.AddListener(OnHomeButtonClicked);
        _pauseMenuReplayButton.onClick.AddListener(OnReplayButtonClicked);
        _pauseMenuSoundButton.onClick.AddListener(OnSoundButtonClicked);
        _lostMenuHomeButton.onClick.AddListener(OnHomeButtonClicked);
        _lostMenuReplayButton.onClick.AddListener(OnReplayButtonClicked);
    }

    private void OnDestroy()
    {
        Observer.Unsubscribe<GameStartEvent>(OnGameStarted);
        Observer.Unsubscribe<GameLostEvent>(OnGameLost);
    }

    private void OnGameStarted(object sender, GameStartEvent eventData)
    {
        _pauseButton.interactable = true;
    }

    private void OnGameLost(object sender, GameLostEvent eventData)
    {
        _pauseButton.interactable = false;
        PauseManager.instance.SetGamePause(true);
        _pauseWindow.SetActive(false);
        _lostWindow.SetActive(true);
    }

    private void OnHomeButtonClicked()
    {
        GameManager.instance.ApplyCollectedCoins();
        SceneManager.LoadScene("MainMenuScene");
    }

    private void OnPauseButtonClick()
    {
        PauseManager.instance.SetGamePause(!PauseManager.instance.IsGamePaused);
        _pauseWindow.SetActive(PauseManager.instance.IsGamePaused);
    }

    private void OnReplayButtonClicked()
    {
        GameManager.instance.ApplyCollectedCoins();
        SceneManager.LoadScene("LevelScene");
    }

    private void OnSoundButtonClicked() 
    {

    }
}
