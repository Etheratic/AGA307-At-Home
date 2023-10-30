using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : GameBehaviour
{


    private bool isTiming;
    
    public float currentTime = 30f;
    public float displayedTime;

    private int addedTime;

    void Start()
    {
        addedTime = 5;
        StartTimer();
    }
       

  
    void Update()
    {
        if(isTiming)
        {
            currentTime -= Time.deltaTime;
            
        }
       
    }

    public void StartTimer()
    {
        //begin timing
        
        isTiming = true;
    }

    public void AddTime()
    {
        currentTime = currentTime + addedTime;
    }
}
