using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int baseLevel = 0;
    public bool baseIsBuilt = false;
    public Slider healthBar;
    public GameObject baseExplosion;
    public AudioSource upgradeSound;

    private BaseScript baseScript;

    public BaseScript.BaseClass currentBase;
    public float newBonusDmg;
    public float newBonusRate;


    BaseScript.BaseClass newBase;
    private void Awake()
    {
        baseScript = GameObject.Find("GameManager").GetComponent<BaseScript>();
        upgradeSound = GetComponent<AudioSource>();
        refreshBaseStats();
    }
    void Start()
    {
        

        if (baseIsBuilt)
        {


            setNewMaxHealth();
            updateBaseStats();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void setNewMaxHealth()
    {
        healthBar.maxValue = currentBase.baseHealth;
        upgradeSound.Play();
    }
    public void updateBaseStats()
    {
        healthBar.value = currentBase.baseHealth;
    }
    public void checkBaseHealth()
    {
        if(currentBase.baseHealth <= 0)
        {
            GameObject explosion = Instantiate(baseExplosion, new Vector3(transform.position.x, transform.position.y + 2.5f), Quaternion.identity);
            baseScript.checkBases();
            Destroy(explosion, 1.5f);
            Destroy(gameObject);
        }
    }
    public void refreshBaseStats()
    {
        newBase = new BaseScript.BaseClass(baseScript.bases[baseLevel].baseHealth, baseScript.bases[baseLevel].bulletDamage, baseScript.bases[baseLevel].bulletRate, baseScript.bases[baseLevel].bulletSpeed, baseScript.bases[baseLevel].baseImage, baseScript.bases[baseLevel].baseUpgradePrice, baseScript.bases[baseLevel].baseHealthPrice, baseScript.bases[baseLevel].baseUpgradeDmgPrice, baseScript.bases[baseLevel].bulletDamageBonusRate, baseScript.bases[baseLevel].bulletRateBonusRate);

        currentBase = newBase;
        GetComponent<SpriteRenderer>().sprite = currentBase.baseImage;
        upgradeSound.Play();
    }
}
