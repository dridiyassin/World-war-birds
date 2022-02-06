using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject birdBullet;
    BirdsStats stats;
    public float shootCooldown;
    float cooldown;

    void Start()
    {
        stats = GetComponent<BirdsStats>();   
    }

    // Update is called once per frame
    void Update()
    {
        if(shootCooldown <= 0)
        {
            birdShooting();
            cooldown = shootCooldown;
        }
    }
    public void birdShooting()
    {

        GameObject bullet = Instantiate(birdBullet, transform.position, Quaternion.identity);
        bullet.transform.Translate(new Vector2(0, stats.bulletSpeed * Time.deltaTime));
        Destroy(bullet, 10f);
    }
}
