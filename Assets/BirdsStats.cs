using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsStats : MonoBehaviour
{
    public float health;
    public float damage;
    public GameObject spawnAfterBirdDies;
    [Header("Below is not used for Explosive Birds")]
    public float bulletRate;
    public float bulletSpeed;

    public void checkHealth()
    {
        if(health <= 0)
        {
            GameObject explosion = Instantiate(spawnAfterBirdDies, transform.position, Quaternion.identity);
            Destroy(explosion, 0.25f);
            Destroy(gameObject);
        }
    }
    public void takeDamage(float dmg)
    {
        health -= dmg;
    }

  
}
