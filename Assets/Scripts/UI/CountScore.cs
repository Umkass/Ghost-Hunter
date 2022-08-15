using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountScore : MonoBehaviour
{
    [SerializeField]Text txtScore;
    public int score = 0;

    private void Awake()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        if (score < 0)
            score = 0;
        txtScore.text = score.ToString();
    }
}
