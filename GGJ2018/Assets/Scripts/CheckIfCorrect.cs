using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckIfCorrect : MonoBehaviour {

    [SerializeField]
    private int checker;
    [SerializeField]
    private int countGear;
    public GameObject effect;
    public GameObject[] cells;
    [SerializeField]
    Transform[] children;
    [SerializeField]
    private int[] gearTag;
    [SerializeField]
    private bool[] correct;
    public bool AllTrue = false;
    public Manager manager;
    public Timer timestop;
    // Use this for initialization
    void Start () {
        checker = 1;
        children = GetComponentsInChildren<Transform> ();
        StartCoroutine(manager.FadeToTransparent ());
        
    }

    public void Fix () {

        GameObject [] buttons = GameObject.FindGameObjectsWithTag ("0");
        for (int i = 0; i < buttons.Length; i++) {
            buttons [i].GetComponent<Image> ().raycastTarget = false;
        }
        if (countGear >= 0 && countGear <=5)
        {
            manager.Restart();
        }
        else {
            for (int i = 1; i < children.Length; i++)
            {
                GearTagNumber gear = children[i].GetComponentInChildren<GearTagNumber>();
                gearTag[i] = gear.GearNumber;
                //Debug.Log(gearTag);
                if (gearTag[i] == int.Parse(children[i].tag))
                {
                    correct[i] = true;
                    checker++;
                }
            }
            Correct(checker);
        }
        
        

    }
    public void Correct(int value)
    {
        if (checker >= 6)
        {
            for (int i = 0; i < children.Length; i++)
            {
                children[i].GetComponentInChildren<Animator>().SetBool("Trigger", true);
            }
            AllTrue = true;
            effect.SetActive(true);
            timestop.check = false;
            manager.LevelComplete();
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                StartCoroutine(LoadNextLevel());
            }
        }
        else
        {
            timestop.check = true;
            manager.Restart();
        }
    }
    public void CheckMe(int value)
    {
        countGear += value;
    }

    IEnumerator LoadNextLevel () {
        int scene = SceneManager.GetActiveScene ().buildIndex;
        yield return new WaitForSeconds (7.3f);
        manager.Window();
        //manager.FadeToOpaque ();
    }

}
