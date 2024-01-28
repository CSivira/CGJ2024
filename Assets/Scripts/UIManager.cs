using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField] GameObject UIScreen;
    // [Header("Player Life")]
    // [SerializeField] PlayerController player;
    // [SerializeField] Image[] hearts;
    [Header("Title")]
    [SerializeField] GameObject titleScreen;
    [Header("Win")]
    [SerializeField] GameObject winScreen;
    [Header("Game Over")]
    [SerializeField] GameObject gameOverScreen;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // public void UpdateLives(){
    //     if (player.maxHealth == player.health) return;
    //     int i = player.maxHealth-1;
    //     while (i >= player.health){
    //         hearts[i].color = Color.black;
    //         i--;
    //     }
    // }

    public void HideTitle()
    {
        titleScreen.SetActive(false);
        UIScreen.SetActive(true);
    }

    public void ShowWin()
    {
        UIScreen.SetActive(false);
        winScreen.SetActive(true);
    }

    public void ShowGameOver()
    {
        UIScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }
}