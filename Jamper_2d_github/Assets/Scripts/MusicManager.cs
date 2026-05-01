using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] private AudioSource _menuMusic;
    [SerializeField] private AudioSource _gameMusic;

    private const string MuteKey = "MusicMuted";

    public bool IsMuted => PlayerPrefs.GetInt(MuteKey, 0) == 1;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            ApplyMuteState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicForScene(scene.name);
    }

    public void ToggleMusic()
    {
        bool newMutedState = !IsMuted;
        PlayerPrefs.SetInt(MuteKey, newMutedState ? 1 : 0);
        ApplyMuteState();
    }

    private void ApplyMuteState()
    {
        bool muted = IsMuted;
        if (_menuMusic != null)
            _menuMusic.mute = muted;
        if (_gameMusic != null)
            _gameMusic.mute = muted;
    }

    private void PlayMusicForScene(string sceneName)
    {
        if (_menuMusic != null) _menuMusic.Stop();
        if (_gameMusic != null) _gameMusic.Stop();

        if (sceneName == "Menu")
        {
            if (_menuMusic != null) _menuMusic.Play();
        }
        else if (sceneName == "Game")
        {
            if (_gameMusic != null) _gameMusic.Play();
        }

        ApplyMuteState();
    }
}









