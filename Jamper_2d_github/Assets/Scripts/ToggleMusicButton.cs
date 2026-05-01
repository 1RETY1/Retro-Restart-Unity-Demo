using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicButton : MonoBehaviour
{
    [SerializeField] private Sprite _musicOnIcon;
    [SerializeField] private Sprite _musicOffIcon;
    [SerializeField] private Image _iconImage;

    private void Start()
    {
        UpdateIcon();
    }

    public void ToggleMusic()
    {
        MusicManager.Instance.ToggleMusic();
        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (_iconImage != null)
        {
            bool isMuted = MusicManager.Instance.IsMuted;
            _iconImage.sprite = isMuted ? _musicOffIcon : _musicOnIcon;
        }
    }
}




