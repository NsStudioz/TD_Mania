using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units_Traps_LineOfSight : MonoBehaviour
{
    //Attributes:
    [SerializeField] private float timeElapsed;
    private float timerThreshold = 3f;

    [SerializeField] bool _LOS_On;

    [Header("Line Of Sight")]
    public GameObject trigger_LOS;
    public GameObject explosion_LOS;


    void Start()
    {
        if (trigger_LOS != null && explosion_LOS != null)
        {
            trigger_LOS.SetActive(false);
            explosion_LOS.SetActive(false);
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

        if (trigger_LOS != null && explosion_LOS != null)
        {
            trigger_LOS.SetActive(true);
            explosion_LOS.SetActive(true);
        }

        _LOS_On = true;
    }

    private void StartLOS_Timer()
    {
        timeElapsed -= Time.deltaTime;

        if (timeElapsed <= 0)
        {
            trigger_LOS.SetActive(false);
            explosion_LOS.SetActive(false);
            _LOS_On = false;
        }
    }
}
