using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Internet : MonoBehaviour
{
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
        if (col.transform.tag == "Enemy")
        {
            Manager.memeScaped();
        }
    }
}
