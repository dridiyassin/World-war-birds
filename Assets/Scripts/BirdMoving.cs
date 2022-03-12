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
        if (transform.position.x <= -11.5)
        {
            flipToRight();
        }
        else if (transform.position.x >= 11.5)
        {
            flipToLeft();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Random.Range(minSpeed, maxSpeed) * Time.deltaTime, 0, 0);

        
        if (isInScreen)
        {
            if (transform.position.x <= -11.5)
            {
                flipToRight();
            } else if (transform.position.x >= 11.5)
            {
                flipToLeft();
            }
        } else
        {
            if (transform.position.x >= -11 && transform.position.x <= 11)
            {
                isInScreen = true;
            }
        }
    }
    void flipToRight()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Abs(minSpeed) * -1;
        transform.localScale = theScale;
        minSpeed = Mathf.Abs(minSpeed);
        maxSpeed = Mathf.Abs(maxSpeed);
    }
    public void flipToLeft()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = Mathf.Abs(minSpeed);
        transform.localScale = theScale;
        minSpeed = Mathf.Abs(minSpeed) * -1;
        maxSpeed = Mathf.Abs(maxSpeed) * -1;
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
