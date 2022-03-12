using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsStats : MonoBehaviour
{
    public float health;
    public float damage;
    public float killCoinReward;
    public float killScoreReward;
    public GameObject spawnAfterBirdDies;
    [Header("Below is not used for Explosive Birds")]
    public float bulletRate;
    public float bulletSpeed;

    PlayerStats playerToReward;

    private void Start()
    {
        playerToReward = GameObject.Find("GameManager").GetComponent<PlayerStats>();
    }

    public void checkHealth()
    {
        if(health <= 0)
        {
            GameObject explosion = Instantiate(spawnAfterBirdDies, transform.position, Quaternion.identity);
            playerToReward.coin += killCoinReward;
            playerToReward.score += killScoreReward;
            playerToReward.updatePlayerStats();
            Destroy(explosion, 0.25f);
            Destroy(gameObject);
        }
    }
    public void takeDamage(float dmg)
    {
        health -= dmg;
    }

  
}
