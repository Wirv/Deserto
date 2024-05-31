using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Singleton;

    [Header("References")] 
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip error;
    [SerializeField] private AudioClip correct;
    [SerializeField] private AudioClip cardFlip;
    [SerializeField] private AudioClip cardInit;
    [SerializeField] private AudioClip endGame;
    
    private void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
        }
    }

    public void PlayError()
    {
        audioSource.clip = error;
        audioSource.Play();
    }
    public void PlayCorrect()
    {
        audioSource.clip = correct;
        audioSource.Play();
    }
    public void PlayEndGame()
    {
        audioSource.clip = endGame;
        audioSource.Play();
    }
    public void PlayFlip()
    {
        audioSource.clip = cardFlip;
        audioSource.Play();
    }
    public void PlayInit()
    {
        audioSource.clip = cardInit;
        audioSource.Play();
    }
}
