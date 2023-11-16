using UnityEngine;
using Events;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    public bool IsGamePaused => _isGamePaused;

    private bool _isGamePaused;

    public void SetGamePause(bool value)
    {
        _isGamePaused = value;
        Time.timeScale = _isGamePaused ? 0f : 1f;
        Observer.Post(this, new PauseEvent { paused = _isGamePaused });
    }

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
    }
}
