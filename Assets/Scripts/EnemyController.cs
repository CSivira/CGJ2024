using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int id;
    public int health = 3;

    [SerializeField] AudioClip eauSound;
    [SerializeField] AudioClip pushSound;
    
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            GetComponent<AudioSource>().clip = eauSound;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().clip = pushSound;
            GetComponent<AudioSource>().Play();
            
            Manager.notifyDead();
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }
}
