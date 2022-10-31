using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units_LineOfSight : MonoBehaviour
{

    //Attributes:
    [SerializeField] private float timeElapsed;
    private float timerThreshold = 3f;

    [SerializeField] bool _LOS_On;

    [Header("Line Of Sight")]
    public GameObject LOS;


    void Start()
    {
        if (LOS != null)
        {
            LOS.SetActive(false);
        }
    }

    private void Update()
    {
        if (_LOS_On)
        {
            StartLOS_Timer();
        }
    }

    public void EnableLOS()
    {
        timeElapsed = timerThreshold;

        if (LOS != null)
        {
            LOS.SetActive(true);     
        }

        _LOS_On = true;
    }

    private void StartLOS_Timer()
    {
        timeElapsed -= Time.deltaTime;

        if (timeElapsed <= 0)
        {
            LOS.SetActive(false);
            _LOS_On = false;
        }
    }


}
