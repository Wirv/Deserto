using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    
    private int scorePoints;

    [Header("References")] 
    public CardsList<GameObject> Cards = new CardsList<GameObject>();
    [HideInInspector] public bool Loading = false;
    
    [SerializeField] private BoardManager board2x2;
    [SerializeField] private BoardManager board2x3;
    [SerializeField] private BoardManager board5x6;

    private BoardManager boardActive;
    private int combo = 0;
    

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

#if UNITY_ANDROID || UNITY_IOS
         Screen.orientation = ScreenOrientation.LandscapeLeft;
#endif
    }

    private void Start()
    {
        HUDManager.Singleton.StartGamePanel.SetActive(true);
        HUDManager.Singleton.MainBtnPanel.SetActive(true);
        
        HUDManager.Singleton.DifficultyBtnPanel.SetActive(false);
        HUDManager.Singleton.EndGamePopup.SetActive(false);
        
        Cards.Clear();
        ScorePoints = PlayerPrefs.GetInt("ScorePoints", 0);

        Cards.ItemAdded += OnItemAdded;
    }

    public void LoadGame()
    {
        
    }

    private void OnItemAdded(GameObject card)
    {
        if (Cards.Count == 2)
        {
            StartCoroutine(CheckCards(Cards[0], Cards[1]));
            Cards.Clear();
        }
        
    }

    private IEnumerator CheckCards(GameObject cardOne, GameObject cardTwo)
    {
        Cards.Clear();
        
        if (cardOne.transform.GetChild(0).gameObject.GetComponent<Image>().mainTexture.name == 
            cardTwo.transform.GetChild(0).gameObject.GetComponent<Image>().mainTexture.name)
        {
            ScorePoints += 100 * combo;

            combo += 1;
            SoundManager.Singleton.PlayCorrect();
                
            if (boardActive.IsEndGame())
            {
                SoundManager.Singleton.PlayEndGame();
                yield return new WaitForSeconds(2);
                HUDManager.Singleton.EndGamePopup.SetActive(true);
            }
        }
        else
        {
            combo = 1;
            SoundManager.Singleton.PlayError();
            yield return new WaitForSeconds(2);
            cardOne.GetComponent<Animator>().SetBool("Show", false);
            cardTwo.GetComponent<Animator>().SetBool("Show", false);
        }
    }

    public void SetScorePoint(int value)
    {
        scorePoints = value;
        HUDManager.Singleton.ScoreTxt.text = scorePoints.ToString();
    }

    public void SetBoardAndStartGame(int index)
    {
        combo = 1;
        if (boardActive != null)
        {
            foreach (var card in boardActive.CardsOnBoard)
            {
                card.GetComponent<Animator>().SetBool("Show", false);
                card.GetComponent<Animator>().Play("BackIdle");
                card.SetActive(false);
            }
            boardActive.gameObject.SetActive(false);
        }
        switch (index)
        {
            case 0:
                boardActive = board2x2;
                break;
            case 1:
                boardActive = board2x3;
                break;
            case 2:
                boardActive = board5x6;
                break;
        }
        
        boardActive.gameObject.SetActive(true);
        StartCoroutine(TurnOnCard());
        
        if(HUDManager.Singleton.EndGamePopup.activeInHierarchy)
            HUDManager.Singleton.EndGamePopup.SetActive(false);
    }

    private IEnumerator TurnOnCard()
    {
        foreach (var card in boardActive.CardsOnBoard)
        {
            SoundManager.Singleton.PlayInit();
            card.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
