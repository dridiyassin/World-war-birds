using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dive : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject diveExplosion;

    public GameObject[] baseslist;
    GameObject[] newBasesList;
    Transform baseToDiveInto;
    
    BirdMoving movements;
    BirdsStats stats;

    void Awake()
    {
        refreshBases();
      
    }

    void refreshBases()
    {
        movements = GetComponent<BirdMoving>();
        stats = GetComponent<BirdsStats>();
        baseslist = GameObject.FindGameObjectsWithTag("Base");
    }

    void checkIfBasesChanged()
    {
        newBasesList = GameObject.FindGameObjectsWithTag("Base");
        if (newBasesList != baseslist)
        {
            refreshBases();
        } else if(newBasesList.Length <= 0 || baseslist.Length <= 0)
        {
            enabled = false;
        }
    }
    private void Start()
    {
        baseToDiveInto = choseBaseToDiveIn();
    }

    // Update is called once per frame

    void Update()
    {
        checkIfBasesChanged();
        
        if (baseslist.Length > 0)
        {
            if ((baseToDiveInto == null) || (!baseToDiveInto.gameObject.activeSelf))
            {
                refreshBases();
                baseToDiveInto = choseBaseToDiveIn();
            }
            else
            {
                setDivePos(baseToDiveInto);
            }
        }
    }

    Transform choseBaseToDiveIn()
    {
        return baseslist[Random.Range(0, baseslist.Length)].transform;
    }

    void setDivePos(Transform chosenBase)
    {
        float distance = Mathf.Abs(transform.position.x - chosenBase.transform.position.x);
        //Debug.Log(distance);
        if(distance <= 1)
        {
            diveIn();
            //Debug.Log("DIVING!");
        }
    }
    void diveIn()
    {
        movements.flipToLeft(); //Used FlipToLeft because if the bird is going right it will dive Upwords Instead of downwords
        transform.rotation = Quaternion.Euler( new Vector3(0f, 0f, 90f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Base"))
        {
            BaseStats bStats = other.gameObject.GetComponent<BaseStats>();
                bStats.currentBase.takeDamage(stats.damage);
            bStats.updateBaseStats();
            bStats.checkBaseHealth();
            GameObject explosion = Instantiate(diveExplosion, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);
            Destroy(gameObject);
        }
    }
    
}
