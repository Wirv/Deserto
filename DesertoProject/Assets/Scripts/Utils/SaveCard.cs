using System.IO;
using UnityEngine;

public class SaveCard : MonoBehaviour
{
    public string IndexCard;

    private void OnEnable()
    {
        if (GameManager.Singleton.Loading)
        {
            if (PlayerPrefs.GetInt(IndexCard, 0) == 1)
            {
                transform.SetSiblingIndex(PlayerPrefs.GetInt(IndexCard + "t", 0));
                GetComponent<Animator>().SetBool("Show", true);
                GetComponent<Animator>().Play("FrontIdle");
            }
        }
        else
        {
            PlayerPrefs.SetInt(IndexCard + "t", transform.GetSiblingIndex());
        }
    }

}
