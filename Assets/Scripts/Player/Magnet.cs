using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    private const float AttractionSpeed = 0.1f;

    [Header("Dependencies")]
    [SerializeReference]
    private Button _magnetButton;
    [SerializeReference]
    private Player _player;
    
    private bool _isActivate = false;

    private void Awake()
    {
        _magnetButton.onClick.AddListener(OnMagnetButtonClick);
    }

    private void OnMagnetButtonClick()
    {
        _isActivate = !_isActivate;
    }

    private void FixedUpdate()
    {
        if (_isActivate) {
            AttractCollectables();
        }
    }

    private void AttractCollectables()
    {
        if ( _player.CurrentZone == null ) { return; }

        foreach (Collectable collectable in _player.CurrentZone.Collectables) {
            collectable.Attract(_player.transform.position, AttractionSpeed);

            if (collectable.CheckIsNear(_player.transform.position)) {
                collectable.Collect(_player);
            }
        }
    }
}
