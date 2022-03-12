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
        cooldown = shootCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;
        if(cooldown <= 0)
        {
            birdShooting();
            cooldown = shootCooldown;
        }
    }
    public void birdShooting()
    {

        GameObject bullet = Instantiate(birdBullet, new Vector3(transform.position.x, transform.position.y - 0.75f), Quaternion.identity);
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -stats.bulletSpeed) *  Time.deltaTime;
        bullet.GetComponent<BulletStats>().currentDamage = stats.damage;
        Destroy(bullet, 10f);
    }
}
