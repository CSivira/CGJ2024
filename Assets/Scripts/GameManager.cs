using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] AudioClip MenuSong;
    [SerializeField] AudioClip GameSongLoop;
    [SerializeField] AudioClip WinSong;
    [SerializeField] AudioClip FailSong;
    [SerializeField] GameObject Player;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    private void Start() {
        GetComponent<AudioSource>().clip = MenuSong;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }

    public void StartGame()
    {
        StartCoroutine(PlayGameSong());
        // UIManager.instance.HideTitle();
    }

    public void Win()
    {
        GetComponent<AudioSource>().clip = WinSong;
        GetComponent<AudioSource>().Play();
        // UIManager.instance.ShowWin();
    }

    public void GameOver()
    {
        GetComponent<AudioSource>().clip = FailSong;
        GetComponent<AudioSource>().Play();
        // UIManager.instance.ShowGameOver();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }
 
    IEnumerator PlayGameSong()
    {
        GetComponent<AudioSource>().clip = GameSongLoop;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
    }
}