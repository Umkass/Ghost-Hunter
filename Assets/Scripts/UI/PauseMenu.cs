using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameStates _gameStates;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] Button btnResume;
    [SerializeField] Button btnPause;
    [SerializeField] Button btnMainMenu;

    void Awake()
    {
        pauseMenu.SetActive(false);
        btnResume.onClick.AddListener(() =>
        {
            _gameStates.Resume();
            pauseMenu.SetActive(false);
        });
        btnPause.onClick.AddListener(() =>
        {
            _gameStates.Pause();
            pauseMenu.SetActive(true);

        });
        btnMainMenu.onClick.AddListener(() =>
        {
            _gameStates.MainMenu();
        });
    }
}
