using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBinded : MonoBehaviour
{
    [SerializeField] bool isBinded = false;
    public float bindDelay = 10f;

    Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();   
    }

    private void Update()
    {
        BindingEnemy();
    }


    private void OnTriggerEnter(Collider binder)
    {
        if (binder.CompareTag("Binder"))
        {   
            D_Trap_Binder bindTrap = binder.GetComponent<D_Trap_Binder>();
            bindDelay = bindTrap.bindingDuration;
            //
            isBinded = true;
        }
    }

    public void BindingEnemy()
    {
        if (isBinded)
        {
            bindDelay -= Time.deltaTime;
            enemy.movingSpeed = enemy.startSpeed * 0f;
        }

        if (bindDelay <= 0f)
        {
            isBinded = false;
            enemy.movingSpeed = enemy.startSpeed;
        }

        if (!isBinded)
        {
            bindDelay = 10f;
        }
    }

/*    public void BindEnemyNewOLD()
    {
        if (isBinded)
        {
            enemy.movingSpeed = enemy.startSpeed * 0;
        }
        else
        {
            enemy.movingSpeed = enemy.startSpeed;
        }
    }*/

}
