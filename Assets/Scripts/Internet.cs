using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet : MonoBehaviour
{
    
    [SerializeField] AudioClip wiiiSound;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    
    private void OnTriggerEnter(Collider col)
    {
        /*if (col.transform.tag == "Enemy")
        {*/
            Debug.Log("sdaa");
                
            GetComponent<AudioSource>().clip = wiiiSound;
            GetComponent<AudioSource>().Play();
            Manager.memeScaped();
        /*}*/
    }
}
