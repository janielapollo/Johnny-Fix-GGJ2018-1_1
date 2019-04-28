using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour {

    public float clockTimer = 60f;
    public Image img;

    public GameObject playBtn;
    public GameObject pauseBtn;
    public Timer timer;
    public GameObject arrow;
    public GameObject blackscreen;
    private GameObject soundMan;
    public GameObject win;
    public GameObject lose;
    SoundsManager soundsManager;
    
    void Start () {
        if(soundMan == null) {
            soundMan = GameObject.Find("SoundsManager");
            soundsManager = soundMan.GetComponent<SoundsManager>();
        }
        soundsManager.StopFirst("BGM1");
        if (Time.timeScale == 0 && PlayerPrefs.GetInt("Checker") == 0)
        {
            blackscreen.SetActive(true);
            StartCoroutine(FadeToTransparent());
            pauseBtn.SetActive(false);
            playBtn.SetActive(true);
            arrow.SetActive(true);
        }
        else if (Time.timeScale == 1 && PlayerPrefs.GetInt("Checker") == 1)
        {
            playBtn.SetActive(false);
            pauseBtn.SetActive(true);
            arrow.SetActive(false);
        }

	}

    public IEnumerator FadeToTransparent () {
        for (float i = 1; i >= 0; i -= Time.unscaledDeltaTime) {
            // set color with i as alpha
            img.color = new Color (0, 0, 0, i);
            yield return null;
        }
    }

    public void FadeToOpaque () {
        // Lerp the colour of the image between itself and black.
        img.color = Color.Lerp (img.color, Color.black, 0.5f * Time.deltaTime);
    }


    public void Restart () {
        PlayerPrefs.SetFloat("SaveTimer", timer.slideVal);
        PlayerPrefs.SetInt("Checker", 1);
        soundsManager.Player("SFX_Function");
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
    public void ResetTheGame()
    {
        FadeToOpaque();
        FreshStart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu () {
        FadeToOpaque ();
        Time.timeScale = 1;
        soundsManager.StopFirst("BGM2");
        soundsManager.Player("SFX_UI");
        soundsManager.Player("BGM1");
        SceneManager.LoadScene (0);

    }

    public void Play() {
        Time.timeScale = 1;
        pauseBtn.SetActive(true);
        playBtn.SetActive(false);
        timer.setFix.interactable = true;
        arrow.SetActive(false);
        soundsManager.Player("BGM2");
        soundsManager.Player("SFX_UI");
    }
    public void Pause()
    {
        soundsManager.Player("SFX_UI");
        Time.timeScale = 0;
        pauseBtn.SetActive(false);
        playBtn.SetActive(true);
        timer.setFix.interactable = false;
        soundsManager.Player("BGM2");
    }
    public void FreshStart()
    {
        PlayerPrefs.SetInt("Checker", 0);
        PlayerPrefs.SetFloat("SaveTimer", clockTimer);
        pauseBtn.SetActive(false);
        playBtn.SetActive(true);
        timer.setFix.interactable = false;
        soundsManager.StopFirst("BGM2");
        soundsManager.Player("SFX_UI");
    }
    public void LevelComplete()
    {
        PlayerPrefs.SetInt("Checker", 0);
        PlayerPrefs.SetFloat("SaveTimer", clockTimer);
        soundsManager.Player("SFX_Complete");
        soundsManager.Player("SFX_Level");
    }
    public void Window() {

        soundsManager.StopFirst("BGM2");
        soundsManager.Player("SFX_UI");
        timer.check = false;
        win.SetActive(true);
        Time.timeScale = 0;
        
    }
    public void LoseWindow()
    {

        soundsManager.StopFirst("BGM2");
        soundsManager.Player("SFX_Negative");
        soundsManager.Player("SFX_UI");
        lose.SetActive(true);
        Time.timeScale = 0;

    }

}
