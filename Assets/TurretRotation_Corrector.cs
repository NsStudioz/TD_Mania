using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation_Corrector : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float turnSpeed;

    void Update()
    {
        LinkRotationToTarget();
    }

    private void LinkRotationToTarget()
    {
        //transform.rotation.y = target.transform.rotation.y;

        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(target.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

}
