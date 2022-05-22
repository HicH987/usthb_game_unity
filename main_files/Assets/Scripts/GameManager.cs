using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI BestTime;
    public GameObject GameOverMenu;
    string bestTimeMinutes;
    string bestTimeSeconds;
    string bestTimeMilliseconds;
    public static bool GameIsPaused = false;
    // public bool GameOver;

    public void EndGame(TimeSpan time, int nbrObjectsCollected)
    {//setup les 2 BOUTTON de GameOverMenu
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        FindObjectOfType<PauseMenu>().GameOver = true;
        Time.timeScale = 0f;

        GameOverMenu.SetActive(true);
        timeText.text = time.Minutes.ToString()+" min "+time.Seconds.ToString()+ " sec";

        bestTimeMinutes = PlayerPrefs.GetInt("BestTimeMinutes", 0).ToString();
        bestTimeSeconds = PlayerPrefs.GetInt("BestTimeSeconds", 0).ToString();
        bestTimeMilliseconds = PlayerPrefs.GetInt("BestTimeMilliseconds", 0).ToString();
        BestTime.text = bestTimeMinutes+" min "+bestTimeSeconds+" sec";
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        // SceneManager.LoadScene("MainGame");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
