using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [HideInInspector] public bool HaveLost = false;
    [SerializeField] GameObject gameOverText;
    [SerializeField] TextMeshProUGUI coinCounterScreen;
    [HideInInspector] public int coinCounter = 0;
    [SerializeField] GameObject gameWinScreen;
    int curCoins;
    bool haveWon = true;
    void Start()
    {
        Time.timeScale = 1;
        HaveLost = false;
        gameOverText.SetActive(false);
        coinCounter = 0;
        curCoins = GameObject.FindGameObjectsWithTag("NormalCoin").Length;
        haveWon = false;
        gameWinScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(HaveLost)
        {
            gameOverText.SetActive(true);
        }
        coinCounterScreen.SetText("Thu thập " + curCoins + " xu để thắng: " + coinCounter + " xu");
        if(coinCounter == curCoins)
        {
            haveWon = true;
        }
        if(haveWon)
        {
            Time.timeScale = 0;
            gameWinScreen.SetActive(true); 
        }
    }
}
