using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float score;
    public float coin;

    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI coinUI;

    public TextMeshProUGUI scoreUIgo;

    private void Update()
    {
        score += Time.deltaTime * 3f;
        updatePlayerStats();
    }
    public void updatePlayerStats()
    {
        scoreUI.text = score.ToString("0");
        scoreUIgo.text = "Score: " + score.ToString("0");
        coinUI.text = coin.ToString();
    }
}
