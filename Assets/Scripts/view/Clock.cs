using UnityEngine;
using UnityEngine.EventSystems;

public class Clock : MonoBehaviour
{
    public EventSystem eventSistem;
    private const int TOTAL_SECONDS = 3;
    private float day;
    private const int DEGREES_PER_DAY = 360;
    private Transform clockHandTransform;
    private bool stop = false;
    
    private void Awake()
    {
        clockHandTransform = transform.Find("pointer");
    }

    private void Update()
    {
        if (day < 1)
        {
            day += Time.deltaTime / TOTAL_SECONDS;
            float dayNormalized = day % 1f;
            clockHandTransform.eulerAngles = new Vector3(0,0,-dayNormalized*DEGREES_PER_DAY);
        }else if(!stop)
            timeOut();
    }

    private void timeOut()
    {
        eventSistem.GetComponent<BalanceamentoController>().sendResult();
        stop = true;
    }
}
