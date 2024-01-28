using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour
{

    enum STAGE
    {
        MENU, GAME, WIN, LOSE
    }

    private STAGE stage;

    public static Manager instance;
    
    public GameObject[] targets;
    public Transform[] spawns;
    public int numMemes = 5;

    public Sprite[] sprites;

    public GameObject enemyPrefab;

    public int memeMaxCount = 3;
    
    // Metrics
    private static int memeScapeCount = 0;
    private static int memeDeadCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;

        stage = STAGE.MENU;
    }
    
    // Ugly booleans
    private bool gameWasCreated = false;

    // Update is called once per frame
    void Update()
    {

        switch (stage)
        {
            case STAGE.MENU:
                break;
            case STAGE.GAME:
                break;
            case STAGE.WIN:
                break;
            case STAGE.LOSE:
                break;
        }

        //Menu condition
        if (stage.Equals(STAGE.WIN) || stage.Equals(STAGE.LOSE) && Input.GetKeyDown("space")) {
            Menu();
        }

        // Create/Start Game
        if (stage.Equals(STAGE.MENU) && Input.GetKeyDown("space"))
        {
            memeScapeCount = 0;
            Create();
        }

        // Lose condition
        if (stage.Equals(STAGE.GAME) && memeScapeCount >= memeMaxCount)
        {
            Lose();
        }
        
        // Win condition
        if (stage.Equals(STAGE.GAME) && memeDeadCount >= numMemes)
        {
            Win();
        }
        
        // Close Game
        if (stage.Equals(STAGE.MENU) && Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    IEnumerator SpawnCoroutine()
    {
        int count = numMemes;
        while (count > 0)
        {
            // Vector3 randomPos = new Vector3(12 + 1, Random.Range(-9, 10), -1);
            Vector3 randomPos = spawns[Random.Range(0, spawns.Length)].position;
            GameObject meme = Instantiate(enemyPrefab, randomPos, Quaternion.identity);

            Transform randomTarget = targets[Random.Range(0, targets.Length)].transform;
            meme.GetComponent<MoveTo>().setTarget(randomTarget);
            meme.GetComponent<EnemyController>().SetId(count);
            meme.GetComponentInChildren<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
            
            count--;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public static void memeScaped()
    {
        memeScapeCount++;
        Debug.Log(memeScapeCount);
    }

    public static void notifyDead()
    {
        memeDeadCount++;
    }

    private void Win()
    {
        stage = STAGE.WIN;
        Debug.Log("Win");
    }

    private void Lose()
    {
        stage = STAGE.LOSE;
        Debug.Log("Lose");
    }

    private void Menu()
    {
        stage = STAGE.MENU;
        Debug.Log("Lose");
    }

    private void Create()
    {
        stage = STAGE.GAME;
        if (!gameWasCreated)
        {
            StartCoroutine(SpawnCoroutine());
            gameWasCreated = true;
        }
    }
}
