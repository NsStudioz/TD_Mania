using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyBinded : MonoBehaviour
{
    [SerializeField] private bool isBinded = false;
    [SerializeField] private float bindDelay = 10f;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update() => BindingEnemy();

    private void OnTriggerEnter(Collider binder)
    {
        if (binder.CompareTag("Binder"))
        {   
            D_Trap_Binder bindTrap = binder.GetComponent<D_Trap_Binder>();
            bindDelay = bindTrap.bindingDuration;
            //
            SetEnemyBind();
        }
    }

    private void BindingEnemy()
    {
        if (isBinded)
        {
            bindDelay -= Time.deltaTime;
            enemy.StopEnemyMovement();
        }

        if (bindDelay <= 0f)
        {
            isBinded = false;
            enemy.ResetEnemyMovementSpeed();
        }
    }

    private void SetEnemyBind()
    {
        isBinded = true;
        bindDelay = 10f;
    }

}
