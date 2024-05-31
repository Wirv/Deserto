using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    private int scorePoints;

    [Header("References")] 
    public List<Sprite> Cards = new List<Sprite>();

    public int ScorePoints
    {
        get
        {
            return scorePoints;
        }

        set
        {
            SetScorePoint(value);
        }
    }

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
    }

    private void Start()
    {
        Cards.Clear();
        ScorePoints = 0;
    }

    public void SetScorePoint(int value)
    {
        scorePoints += value;
        HUDManager.Singleton.ScoreTxt.text = scorePoints.ToString();
    }
}
