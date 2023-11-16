using UnityEngine;
using UnityEngine.UI;

public class Magnet : MonoBehaviour
{
    private const float AttractionSpeed = 0.1f;

    [Header("Properties")]
    [SerializeField]
    private Color _magnetButtonBasicColor;
    [SerializeField]
    private Color _magnetButtonActiveColor;

    [Header("Dependencies")]
    [SerializeReference]
    private Button _magnetButton;
    [SerializeReference]
    private Image _magnetButtonImage;
    [SerializeReference]
    private SpriteRenderer _spriteRenderer;
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
        _spriteRenderer.enabled = _isActivate;
        _magnetButtonImage.color = _isActivate ? _magnetButtonActiveColor : _magnetButtonBasicColor;
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
            collectable.Attract(transform.position, AttractionSpeed);

            if (collectable.CheckIsNear(transform.position)) {
                collectable.Collect(_player);
            }
        }
    }
}
