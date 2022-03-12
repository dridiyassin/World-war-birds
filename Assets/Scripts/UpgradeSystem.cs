using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UpgradeSystem : MonoBehaviour
{
    // Start is called before the first frame update

    public Button upgradeButt;
    public Button repairButt;
    public Button upgradeDmgButt;

    UpgradePrice upgradePriceUI;
    UpgradePrice repairPriceUI;
    UpgradePrice upgradeDmgPriceUI;

    BaseStats stats;

    PlayerStats playerStats;
    void Start()
    {
        upgradeButt = transform.GetChild(0).GetChild(0).GetComponent<Button>();
        repairButt = transform.GetChild(0).GetChild(1).GetComponent<Button>();
        upgradeDmgButt = transform.GetChild(0).GetChild(2).GetComponent<Button>();

        upgradePriceUI = upgradeButt.gameObject.GetComponent<UpgradePrice>();
        repairPriceUI = repairButt.gameObject.GetComponent<UpgradePrice>();
        upgradeDmgPriceUI = upgradeDmgButt.gameObject.GetComponent<UpgradePrice>();

        playerStats = GameObject.Find("GameManager").GetComponent<PlayerStats>();

        stats = GetComponent<BaseStats>();

        upgradeButt.onClick.AddListener(levelUp);
        repairButt.onClick.AddListener(healBase);
        upgradeDmgButt.onClick.AddListener(delegate { upgradeBaseDamage(); });

        

        refreshPriceUI();

    }

    void refreshPriceUI()
    {
        upgradePriceUI.priceText.text = stats.currentBase.baseUpgradePrice.ToString();
        repairPriceUI.priceText.text = stats.currentBase.baseHealthPrice.ToString();
        upgradeDmgPriceUI.priceText.text = stats.currentBase.baseUpgradeDmgPrice.ToString();
    }

    public void levelUp()
    {
        if (playerStats.coin >= stats.currentBase.baseUpgradePrice)
        {
            playerStats.coin -= stats.currentBase.baseUpgradePrice;
            stats.baseLevel += 1;
            stats.refreshBaseStats();
            stats.setNewMaxHealth();
            stats.updateBaseStats();
            refreshPriceUI();
            upgradeDmgButt.interactable = true;
        }
    }
    public void healBase()
    {
        if (playerStats.coin >= stats.currentBase.baseHealthPrice)
        {
            playerStats.coin -= stats.currentBase.baseHealthPrice;
            stats.currentBase.baseHealth = stats.healthBar.maxValue;
            stats.updateBaseStats();
            stats.upgradeSound.Play();
           
        }
    }
    public void upgradeBaseDamage()
    {
        if (playerStats.coin >= stats.currentBase.baseUpgradeDmgPrice)
        {
            upgradeDmgButt.interactable = false;
            playerStats.coin -= stats.currentBase.baseUpgradeDmgPrice;
            stats.newBonusDmg += stats.currentBase.bulletDamageBonusRate;
            stats.newBonusRate += stats.currentBase.bulletRateBonusRate;
            stats.upgradeSound.Play();
           
            
        }

    }

    // Update is called once per frame
   
}
