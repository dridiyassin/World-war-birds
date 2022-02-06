using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    // Start is called before the first frame update
    public int baseLevel = 0;
    public bool baseIsBuilt = false;
    private BaseScript baseScript;

    public BaseScript.BaseClass currentBase;

    private void Awake()
    {
        baseScript = GameObject.Find("GameManager").GetComponent<BaseScript>();
    }
    void Start()
    {
        if (baseIsBuilt)
        {
            refreshBaseStats();
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
    void refreshBaseStats()
    {
        currentBase = baseScript.bases[baseLevel];
        GetComponent<SpriteRenderer>().sprite = currentBase.baseImage;
    }
}
