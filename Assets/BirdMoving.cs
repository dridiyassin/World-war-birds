using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isInScreen;
    public float minSpeed = -1;
    public float maxSpeed = -5;

   

    BirdsStats stats;
    void Start()
    {
        stats = GetComponent<BirdsStats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Random.Range(minSpeed, maxSpeed) * Time.deltaTime, 0, 0);

        
        if (isInScreen)
        {
            if (transform.position.x <= -11.5 || transform.position.x >= 11.5)
            {
                flip();
            }
        } else
        {
            if (transform.position.x >= -11 && transform.position.x <= 11)
            {
                isInScreen = true;
            }
        }
    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        minSpeed *= -1;
        maxSpeed *= -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("bullet"))
        {
            stats.takeDamage(other.gameObject.GetComponent<BulletStats>().currentDamage);
            Destroy(other.gameObject);
            stats.checkHealth();
        }
    }
}
