using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button btnPlay;
    [SerializeField] Button btnQuit;

    private void Awake()
    {
        btnPlay.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        });

        btnQuit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
