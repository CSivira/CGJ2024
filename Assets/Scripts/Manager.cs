using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    
    public GameObject[] targets;
    public int numMemes;

    public GameObject enemyPrefab;
    
    // Metrics
    private static int memeScapeCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        
        if (numMemes.IsUnityNull()) numMemes = 1;
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator SpawnCoroutine()
    {
        int count = numMemes;
        while (count > 0)
        {
            Vector3 randomPos = new Vector3(12 + 1, Random.Range(-9, 10), -1);
            GameObject meme = Instantiate(enemyPrefab, randomPos, Quaternion.identity);

            Transform randomTarget = targets[Random.Range(0, targets.Length)].transform;
            meme.GetComponent<MoveTo>().setTarget(randomTarget);
            
            count--;
            yield return new WaitForSeconds(0.25f);
        }
    }

    public static void memeScaped()
    {
        memeScapeCount++;
        Debug.Log(memeScapeCount);
    }
}
