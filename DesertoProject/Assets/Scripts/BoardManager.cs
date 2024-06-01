using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class BoardManager : MonoBehaviour
{
    public List<GameObject> CardsOnBoard = new List<GameObject>();

    private void OnEnable()
    {
        if(!GameManager.Singleton.Loading)
            RandomizeCards();
    }

    private void RandomizeCards()
    {
        // Mescola la lista dei figli
        for (int i = 0; i < CardsOnBoard.Count; i++)
        {
            Transform temp = CardsOnBoard[i].transform;
            int randomIndex = Random.Range(i, CardsOnBoard.Count);
            CardsOnBoard[i] = CardsOnBoard[randomIndex];
            CardsOnBoard[randomIndex] = temp.gameObject;
        }

        // Reimposta la posizione dei figli nel GridLayoutGroup
        for (int i = 0; i < CardsOnBoard.Count; i++)
        {
            CardsOnBoard[i].transform.SetSiblingIndex(i);
        }
    }

    public bool IsEndGame()
    {
        int count = 0;
        foreach (var card in CardsOnBoard)
        {
            if (card.GetComponent<Animator>().GetBool("Show"))
            {
                count += 1;
            }
        }

        if (count == CardsOnBoard.Count) 
            return true;
        else 
            return false;
    }
}
