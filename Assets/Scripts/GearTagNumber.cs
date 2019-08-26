using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearTagNumber : MonoBehaviour
{
    public int GearNumber;
    [SerializeField]
    private Transform origParent;
    public bool ChangePos;
    public GameObject checkManager;
    [SerializeField]
    CheckIfCorrect corrector;
    private void Start()
    {
        origParent = transform.parent;
        corrector = checkManager.GetComponent<CheckIfCorrect>();
    }
    private void FixedUpdate()
    {
        if (transform.parent != origParent && ChangePos == false)
        {
            corrector.CheckMe(1);
            ChangePos = true;
        }
    }
}
