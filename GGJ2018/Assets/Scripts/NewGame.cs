using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class NewGame : MonoBehaviour
{
    public GameObject LoadingObject;
    public Slider LoadingBar;
    private GameObject soundMan;
    SoundsManager soundsManager;
    private void Start()
    {
        if (soundMan == null)
        {
            soundMan = GameObject.Find("SoundsManager");
            soundsManager = soundMan.GetComponent<SoundsManager>();
        }
        soundsManager.StopFirst("BGM2");
        soundsManager.Player("BGM1");
    }
    public void StartGame()
    {
        soundsManager.Player("SFX_UI");
        PlayerPrefs.SetFloat("SaveTimer", 120f);
        PlayerPrefs.SetInt("Checker", 0);
        StartCoroutine(LoadAsynchronously(1));
        
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingObject.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingBar.value = progress;
            yield return null;
        }
    }
}
