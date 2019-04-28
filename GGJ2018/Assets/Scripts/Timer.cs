using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float slideVal;
    public Slider slider;
    public Text text;
    public bool check;
    public Button setFix;

    public Manager manager;
    void Start() {

        if (PlayerPrefs.GetInt("Checker") == 1)
        {
            slideVal = PlayerPrefs.GetFloat("SaveTimer");
            Time.timeScale = 1;
            setFix.interactable = true;
        }
        else
        {
            slideVal = manager.clockTimer;
            Time.timeScale = 0;
            setFix.interactable = false;
        }
        check = true;
    }

    void Update() {

        if (slideVal > 0 && check == true)
        {
            if (slideVal >= 0) {
                slideVal -= Time.deltaTime;
                slider.value = slideVal;
                
            }
            string minutes = Mathf.Floor(slideVal / 60).ToString("00");
            string seconds = (slideVal % 60).ToString("00");
            //This will change the time in frames
            text.text = minutes + ":" + seconds;
            if (slideVal <= -1)
            {
                text.text = "00:00";
                check = false;
                StartCoroutine(LoadNextLevel());
                
            }


        }



        }
        IEnumerator LoadNextLevel()
        {
            yield return new WaitForSeconds(2.5f);
            manager.LoseWindow();
        }

    }

