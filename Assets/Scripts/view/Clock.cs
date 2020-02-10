using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clock : MonoBehaviour
{
    public EventSystem eventSistem;
    private const int TOTAL_SECONDS = 1;
    private float day;
    private const int DEGREES_PER_DAY = 360;
    private Transform clockHandTransform;
    
    private void Awake()
    {
        clockHandTransform = transform.Find("pointer");
    }

    private void Update()
    {
        day += Time.deltaTime / TOTAL_SECONDS;
        float dayNormalized = day % 1f;
        clockHandTransform.eulerAngles = new Vector3(0,0,-dayNormalized*DEGREES_PER_DAY);
        
        if(day>1)
            timeOut();
    }

    private void timeOut()
    {
        eventSistem.GetComponent<BalanceamentoController>().sendResult();
    }
}
