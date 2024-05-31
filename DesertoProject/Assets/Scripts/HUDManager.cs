using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager Singleton;

    [Header("References")] 
    public TMP_Text ScoreTxt;
    
    [Header("Panels")]
    public GameObject StartGamePanel;
    public GameObject EndGamePopup;
    public GameObject MainBtnPanel;
    public GameObject DifficultyBtnPanel;
    
    [Header("InGame")]
    [SerializeField] private Button quitBtn;
    
    [SerializeField] private Button EasyBtn;
    [SerializeField] private Button MediumBtn;
    [SerializeField] private Button HardBtn;
    
    [Header("MainMenu")]
    [SerializeField] private Button EasyBtn2;
    [SerializeField] private Button MediumBtn2;
    [SerializeField] private Button HardBtn2;
    
    [SerializeField] private Button StartBtn;
    [SerializeField] private Button LoadBtn;
    [SerializeField] private Button ExitBtn;

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
        ExitBtn.onClick.AddListener(() => {Application.Quit();});
        
        EasyBtn.onClick.AddListener(() => { GameManager.Singleton.SetBoardAndStartGame(0);});
        MediumBtn.onClick.AddListener(() => { GameManager.Singleton.SetBoardAndStartGame(1);});
        HardBtn.onClick.AddListener(() => { GameManager.Singleton.SetBoardAndStartGame(2);});
        EasyBtn2.onClick.AddListener(() => { GameManager.Singleton.SetBoardAndStartGame(0); StartGamePanel.SetActive(false);});
        MediumBtn2.onClick.AddListener(() => { GameManager.Singleton.SetBoardAndStartGame(1); StartGamePanel.SetActive(false);});
        HardBtn2.onClick.AddListener(() => { GameManager.Singleton.SetBoardAndStartGame(2); StartGamePanel.SetActive(false);});
        
        StartBtn.onClick.AddListener(() => {MainBtnPanel.SetActive(false); DifficultyBtnPanel.SetActive(true);});
        LoadBtn.onClick.AddListener(() => { StartGamePanel.SetActive(false); GameManager.Singleton.Loading = true; GameManager.Singleton.LoadGame();}); 
    }
}
