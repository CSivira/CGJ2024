using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int id;
    public int health = 3;

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
            Manager.
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Manager.notifyDead();
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Finish")
        {
            Destroy(gameObject);
            // Posible animacion de entrar al internet
        }
    }
}
