using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDie : MonoBehaviour
{
    public GameObject dieEffect;
    public GameObject reward;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject collisionObject = col.gameObject;
        
        if (collisionObject.name != "Player")
        {
            Die();
        }

        if (collisionObject.CompareTag("Enemy"))
        {
            Instantiate(reward, transform.position, Quaternion.identity);
            Destroy(collisionObject);
        }
    }

    void Die()
    {
        if (dieEffect != null)
        {
            Instantiate(dieEffect, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
