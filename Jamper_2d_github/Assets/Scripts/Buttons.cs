using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    private bool _isPaused = false;

    [Header("Panels")]
    [SerializeField] private GameObject _PanelShop;
    [SerializeField] private GameObject _PausedPanel;
    [SerializeField] private GameObject _GamePlayPanel;
    [SerializeField] private GameObject _UIPanel;
    [SerializeField] private GameObject _infoPanel;


    public void Info()
    {
        _UIPanel.SetActive(false);
        _infoPanel.SetActive(true);
    }
    public void BackInfo()
    {
        _UIPanel.SetActive(true);
        _infoPanel.SetActive(false);
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void Pause()
    {
        if (!_isPaused)
        {
            _PausedPanel.SetActive(true);
            _GamePlayPanel.SetActive(false);
            Time.timeScale = 0;
            _isPaused = true;
        }
        else if (_isPaused)
        {
            _PausedPanel.SetActive(false);
            _GamePlayPanel.SetActive(true);
            Time.timeScale = 1;
            _isPaused = false;
        }
    }
}



