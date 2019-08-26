using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation_Arrow : MonoBehaviour
{
    public float speed;
    bool endPoint;
    public float timer = 2f;
    bool stop;
    public Image arrow;
    private void Update()
    {
        
        if(Time.timeScale == 0) {
            if (!stop) {
                timer -= Time.unscaledDeltaTime;
            }
            
            if (timer <= -7)
            {
                arrow.enabled = true;
                stop = true;
            }

            if (this.transform.position.x >= 113.0f)
            {
                endPoint = false;
            }
            if (this.transform.position.x <= 109.0f)
            {
                endPoint = true;
            }
            if (endPoint)
            {
                this.transform.position += Vector3.right * speed * Time.unscaledDeltaTime;

            }
            else
            {
                this.transform.position -= Vector3.right * speed * Time.unscaledDeltaTime;
            }
        }
        
    }

}
