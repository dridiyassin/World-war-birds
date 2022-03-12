using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInteraction : MonoBehaviour
{
    BaseStats stats;
    void Start()
    {
        stats = GetComponent<BaseStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("birdBullet"))
        {
            stats.currentBase.takeDamage(other.gameObject.GetComponent<BulletStats>().currentDamage);
            stats.updateBaseStats();
            stats.checkBaseHealth();
            Destroy(other.gameObject);
        }
    }
}
