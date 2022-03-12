using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsManager : MonoBehaviour
{
    public Transform rightSpawnPos;
    public Transform leftSpawnPos;
    public GameObject normalBird;
    public float normalBirdCooldown;
    public GameObject explosiveBird;
    public float explosiveBirdCooldown;
    public GameObject armoredBird;
    public float armoredBirdCooldown;

    [Header("Difficulty Manager")]
    public float normalBirdFasterRate;
    public float explosiveBirdFasterRate;
    public float armoredBirdFasterRate;

    public float minCoolDown; // +1 min cooldown for explosive and armored


    private float normalWaitTime;
    private float explosiveWaitTime;
    private float armoredWaitTime;

    /*private IEnumerator normalBirdEnum;
    private IEnumerator explosiveBirdEnum;
    private IEnumerator armoredBirdEnum;*/
    private void Start()
    {
        normalWaitTime = normalBirdCooldown;
        explosiveWaitTime = explosiveBirdCooldown;
        armoredWaitTime = armoredBirdCooldown;
       /* normalBirdEnum = spawnNormalBird(normalBirdCooldown);
        explosiveBirdEnum = spawnExplosiveBird(explosiveBirdCooldown);
        armoredBirdEnum = spawnArmoredBird(armoredBirdCooldown);
        startAllCourutine();*/
    }

    /*void startAllCourutine()
    {
        

        StartCoroutine(normalBirdEnum);
        StartCoroutine(explosiveBirdEnum);
        StartCoroutine(armoredBirdEnum);
    }*/
    private void Update()
    {
        normalWaitTime -= Time.deltaTime;
        explosiveWaitTime -= Time.deltaTime;
        armoredWaitTime -= Time.deltaTime;
        if (normalWaitTime <= 0)
        {
            normalBirdSpawner();
            normalWaitTime = normalBirdCooldown;
          
        }
        if(explosiveWaitTime <= 0)
        {
            explosiveBirdSpawner();
            explosiveWaitTime = explosiveBirdCooldown;
           
        }
        if(armoredWaitTime <= 0)
        {
            armoredBirdSpawner();
            armoredWaitTime = armoredBirdCooldown;
        }
        
        
        
        if (normalBirdCooldown >= minCoolDown)
        {
            normalBirdCooldown -= normalBirdFasterRate * Time.deltaTime;
        }
        if (explosiveBirdCooldown >= (minCoolDown +0.5f))
        {
            explosiveBirdCooldown -= explosiveBirdFasterRate * Time.deltaTime;
        }
        if (armoredBirdCooldown >= (minCoolDown +0.5f))
        {
            armoredBirdCooldown -= armoredBirdFasterRate * Time.deltaTime;
        }
    }

    Vector3 setSpawnPosition() //Chose which side bird spawn then give it random Y (offset -2, 2)
    {
        int rightOrLeft = (int)Mathf.Round(Random.Range(0.0f,1.0f)); //0 for left / 1 for right

        Transform chosenSpawnSide;
        if (rightOrLeft == 0)
            chosenSpawnSide = leftSpawnPos;
        else
            chosenSpawnSide = rightSpawnPos;

        return new Vector3(chosenSpawnSide.position.x, chosenSpawnSide.position.y + Random.Range(-2f, 2f));
    }

    private void normalBirdSpawner()
    {

            Instantiate(normalBird, setSpawnPosition(), Quaternion.identity);

    }
    private void explosiveBirdSpawner()
    {
   
           
            Instantiate(explosiveBird, setSpawnPosition(), Quaternion.identity);

    }
    private void armoredBirdSpawner()
    {

            
            Instantiate(armoredBird, setSpawnPosition(), Quaternion.identity);
   
    }
    /*private IEnumerator spawnNormalBird(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(normalBird, setSpawnPosition(), Quaternion.identity);
        }
    }
   
    private IEnumerator spawnExplosiveBird(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(explosiveBird, setSpawnPosition(), Quaternion.identity);
        }
    }
    private IEnumerator spawnArmoredBird(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            Instantiate(armoredBird, setSpawnPosition(), Quaternion.identity);
        }
    }*/

}
