using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownLogic : MonoBehaviour
{
    int countDownStartValue = 0;
    [SerializeField] private TextMeshProUGUI timerUIMeshPro;

    public GameObject nbr;
    private int nbr_obj1 = 0;
    private int nbr_obj2 = 0;
    private int bestTimeMinutes;
    private int bestTimeSeconds;
    TimeSpan spanTime = TimeSpan.FromSeconds(0);
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
    }

    void countDownTimer()
    {
        //somme des objs collecter < au total
        nbr_obj1 = nbr.GetComponent<PlayerInventory>().NumberOfObjects;
        nbr_obj2 = nbr.GetComponent<PlayerInventory>().NumberOfReleve;

        //if still objects to collect
        if ((nbr_obj1 + nbr_obj2) < 3)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            timerUIMeshPro.text = spanTime.Minutes + " min " + spanTime.Seconds + "s";
            countDownStartValue++;
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            //if player collect the total number of objects
            //update best time if the player id better
            // PlayerPrefs.DeleteKey("BestTimeMinutes");
            // PlayerPrefs.DeleteKey("BestTimeSeconds");
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            bestTimeMinutes = PlayerPrefs.GetInt("BestTimeMinutes", 0);
            bestTimeSeconds = PlayerPrefs.GetInt("BestTimeSeconds", 0);
            // UnityEngine.Debug.Log("bestTime"+ bestTime);
            // UnityEngine.Debug.Log("spanTime"+ spanTime.Seconds);
            if (bestTimeMinutes == 0 && bestTimeSeconds == 0)
            {
                PlayerPrefs.SetInt("BestTimeMinutes", spanTime.Minutes);
                PlayerPrefs.SetInt("BestTimeSeconds", spanTime.Seconds);
                PlayerPrefs.Save();
            }else
            {
                if(spanTime.Minutes <= bestTimeMinutes)
                {
                    if(spanTime.Minutes == bestTimeMinutes)
                    {
                        if(spanTime.Seconds < bestTimeSeconds)
                        {
                            // UnityEngine.Debug.Log("NEW BEST TIME !!");

                            PlayerPrefs.SetInt("BestTimeMinutes", spanTime.Minutes);
                            PlayerPrefs.SetInt("BestTimeSeconds", spanTime.Seconds);
                            PlayerPrefs.Save();
                        }
                    }else
                    {
                        PlayerPrefs.SetInt("BestTimeMinutes", spanTime.Minutes);
                        PlayerPrefs.SetInt("BestTimeSeconds", spanTime.Seconds);
                        PlayerPrefs.Save();
                    }
                }
            }
            
            //call EndGame (GameOver)
            FindObjectOfType<GameManager>().EndGame(spanTime, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
