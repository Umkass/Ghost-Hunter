using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CountHearts : MonoBehaviour
{
    [SerializeField] GameStates _gameStates;
    [SerializeField] List<Image> hearts = new List<Image>();
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Sprite filledHeart;
    int countOfHearts = 3;

    void Awake()
    {
        FillHearts();
    }

    void FillHearts()
    {
        foreach (var item in hearts)
        {
            item.sprite = filledHeart;
        }
    }

    public void DecreaseHeart()
    {
        if(countOfHearts !=0)
        {
            countOfHearts--;
            hearts[countOfHearts].sprite = emptyHeart;
            if (countOfHearts == 0)
            {
                _gameStates.MainMenu();
            }
        }
    }
}
