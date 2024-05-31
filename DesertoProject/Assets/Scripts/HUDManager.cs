using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Singleton;

    [Header("References")] 
    public TMP_Text ScoreTxt;
    
    [SerializeField] private Button quitBtn;

    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
    }

    private void Start()
    {
        quitBtn.onClick.AddListener(() => {Application.Quit();});
    }
}
