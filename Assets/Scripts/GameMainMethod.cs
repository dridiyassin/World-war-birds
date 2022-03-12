using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameMainMethod : MonoBehaviour
{

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void gameOver(GameObject gameOverPanel)
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void showPanel(GameObject panelToShow)
    {
        panelToShow.SetActive(true);
    }
    public void hidePanel(GameObject panelToHide)
    {
        panelToHide.SetActive(false);
    }
    public void startGame()
    {
        Time.timeScale = 1;
    }
    public void restartGame()
    {
        Time.timeScale = 1f;
        Debug.Log("restarting");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
