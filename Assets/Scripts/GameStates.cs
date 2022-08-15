using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum GameState
{
    Play,
    Pause,
    GameOver
}

public class GameStates : MonoBehaviour
{
    GameState currentState;

    void Awake()
    {
        currentState = GameState.Play;
        DontDestroyOnLoad(gameObject);
    }
    public void Pause()
    {
        currentState = GameState.Pause;
        Time.timeScale = 0;
    }
    public void Resume()
    {
        currentState = GameState.Play;
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        currentState = GameState.GameOver;
        SceneManager.LoadScene("MainMenu",LoadSceneMode.Single);
    }
}
