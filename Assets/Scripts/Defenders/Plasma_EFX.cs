using System;
using UnityEngine;

public class Plasma_EFX : MonoBehaviour
{

    [Header("Effects")]
    [SerializeField] ParticleSystem plasmaEFX;
    [SerializeField] ParticleSystem plasmaEFX_2;

    [Header("Properties")]
    [SerializeField] Vector3 efx_ScaleChange = new Vector3(0.5f, 0.5f, 0.5f);
    //
    [SerializeField] float timeElapsed;
    [SerializeField] float timeThreshold;
    [SerializeField] float endTimer = 0f;

    // EVENT:
    public static event Action OnPlasmaBoomSFX;

    void Start()
    {
        OnPlasmaBoomSFX?.Invoke();
        timeElapsed = timeThreshold;
    }

    void Update()
    {
        timeElapsed -= Time.deltaTime;
        //
        plasmaEFX.transform.localScale += efx_ScaleChange * Time.deltaTime;
        plasmaEFX_2.transform.localScale += efx_ScaleChange * Time.deltaTime;

        if (timeElapsed <= endTimer)
        {
            Destroy(gameObject);
        }
    }
}
