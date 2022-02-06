using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [System.Serializable]
    public class BaseClass
    {
        public float baseHealth;
        public float bulletDamage;
        public float bulletRate;
        public float bulletSpeed;
        public Sprite baseImage;

       /* BaseClass(float hp, float dmg, float rate, float speed, Sprite baseImg)
        {
            baseHealth = hp;
            bulletDamage = dmg;
            bulletRate = rate;
            bulletSpeed = speed;
            baseImg = baseImage;
        }*/
        public void takeDamage(float dmg)
        {
            baseHealth -= dmg;
        }
    }

    public BaseClass[] bases;
    public GameObject basesParent;
    public GameObject[] baseSpots;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void checkBases()
    {
        if(basesParent.transform.childCount <= 1)
        {
            gameOver();
        }
    }
}
