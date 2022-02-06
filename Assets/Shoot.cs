using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    
    public GameObject bullet;
    Vector3 myScreenPos;
    float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myScreenPos = Camera.main.WorldToScreenPoint(transform.position);
        
       
        //refreshBases();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shootBullet();
        }
    }
    void shootBullet()
    {
        GameObject bulletShoot = Instantiate(bullet, transform.position, Quaternion.identity);
        Vector3 direction = (Input.mousePosition - myScreenPos).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletShoot.transform.rotation = Quaternion.Euler(0f, 0f, angle);
        bulletSpeed = GetComponent<BaseStats>().currentBase.bulletSpeed;
        Debug.Log(bulletSpeed);
        bulletShoot.GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x, direction.y) * bulletSpeed * Time.deltaTime;
        Destroy(bulletShoot, 5f);
    }
}
