using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims_Template : MonoBehaviour
{
    // BASE CLASS FOR ANIMATIONS AND ANIMATOR CONTROLLER; SUITABLE FOR DEFENDING UNITS (All Turrets & Traps)
    [Header("Animations")]
    [SerializeField] protected Animator _animController = null;
    [SerializeField] protected string anim_IdleName;
    [SerializeField] protected string anim_FireName;
    [SerializeField] protected string anim_BuildName;
    [SerializeField] protected string anim_RemoveName;
    [SerializeField] protected bool isDefUnitReady = false;

    private void Awake()
    {
        _animController = GetComponent<Animator>();
    }

    public void EnableDefendingUnit()
    {
        isDefUnitReady = true;
    }
    public void DisableDefendingUnit()
    {
        isDefUnitReady = false;
    }

    public void RemoveDefendingUnit()
    {
        _animController.Play(anim_RemoveName);
    }

    public void DestroyDefendingUnit()
    {
        Destroy(gameObject);
    }


}
