using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timer;
    public float gameTime;
    public bool stopTimer;
    public bool start;
    private bool first =true;
    float startTime;
    void Start()
    {
        startTime = gameTime;
        stopTimer = false;
        timer.maxValue = gameTime;
        timer.value = gameTime;
    }
    void Update()
    {
        if (start)
        {
           
            if (first)
            {
                
                gameTime = timer.maxValue+ Time.time;
                first = false;
            }
                
          
            
            float time = gameTime- Time.time;

            if (time <= 0)
            {
                stopTimer = true;
            }
            if (stopTimer == false)
            {
                timer.value = time;
                
            }
        }
        
    }
    public void resTime()
    {
        timer.value = gameTime;
        first = true;
        stopTimer = false;
        start = false;

    }
}
