using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheelLeft : MonoBehaviour {

    public float speed = 0.001f;
    public CheckIfCorrect check;

    // Update is called once per frame
    void Update () {
        if(Time.timeScale == 1) {
            if (check.AllTrue == true)
            {
                speed = 0.010f;
            }

            this.transform.Rotate(0, 0, 1000 * speed);

        }

    }

}

