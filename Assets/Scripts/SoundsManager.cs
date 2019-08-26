using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundsManager : MonoBehaviour
{
    private static SoundsManager instance;
    [SerializeField]
    private string currentPlaying;
    [SerializeField]
    private bool isPlaying;
    private int currentIndex;
    [SerializeField]
    private Sounds[] sounds = null;
    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
            //Creating the BGM and SFX sound
            for (int i = 0; i < sounds.Length; i++)
            {
                GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].name);
                _go.transform.SetParent(this.transform);
                sounds[i].SetSource(_go.AddComponent<AudioSource>());
            }
        }
    }
    public void Player(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                currentPlaying = sounds[i].name;
                currentIndex = i;
                
                if (Time.timeScale == 0)
                {
                    sounds[i].Pause();
                    isPlaying = false;
                }
                else
                {
                    sounds[i].Play();
                    isPlaying = true;
                }

            }
        }
    }
    public void StopBGM()
    {
        if (PlayerPrefs.GetFloat("Checker") == 0 && isPlaying)
        {
            sounds[currentIndex].Stop();
            isPlaying = false;
            return;
        }
    }
    public void StopFirst(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == _name)
            {
                sounds[i].Stop();
                isPlaying = false;
            }
        }
    }
}
