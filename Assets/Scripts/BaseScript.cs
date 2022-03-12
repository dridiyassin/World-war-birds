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
        public float baseUpgradePrice;
        public float baseHealthPrice;
        public float baseUpgradeDmgPrice;
        public Sprite baseImage;

        [Header("Upgrades")]
        public float bulletDamageBonusRate;
        public float bulletRateBonusRate;

         public BaseClass(float hp, float dmg, float rate, float speed, Sprite baseImg, float upPrice, float hpPrice, float upDmgPrice , float bonusDmg, float bonusRate)
         {
             baseHealth = hp;
             bulletDamage = dmg;
             bulletRate = rate;
             bulletSpeed = speed;
             baseImage = baseImg;
             baseUpgradePrice = upPrice;
            baseHealthPrice = hpPrice;
            baseUpgradeDmgPrice = upDmgPrice;
            bulletDamageBonusRate = bonusDmg;
            bulletRateBonusRate = bonusRate;
             
         } /*!!!!! CONSTRUCTOR IS NOT NEEDED (Values filled in inspector) !!!!*/
        public void takeDamage(float dmg)
        {
            baseHealth -= dmg;
        }
    }

    public BaseClass[] bases;
    public GameObject panelWhenGameOver;
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
    void gameOverMethod() { GetComponent<GameMainMethod>().gameOver(panelWhenGameOver); }
    public void checkBases()
    {
        if(basesParent.transform.childCount <= 1)
        {
            
            Invoke("gameOverMethod" , 2f);
        }
    }
}
