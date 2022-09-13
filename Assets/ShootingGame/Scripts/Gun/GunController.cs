using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private Transform attackPoint;
    [SerializeField]
    private float attackTime;


    private float currentAttackTime;
    private bool isAttacked;
    void Start()
    {
        currentAttackTime = attackTime;
    }

    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        //”ñ“¯Šúˆ—‚ðŽg‚¤
        attackTime += Time.deltaTime;
        if (attackTime > currentAttackTime)
        {
            isAttacked = true;
        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (isAttacked)
            {
                //Instatiate
                Instantiate(gun, attackPoint.position, Quaternion.identity);
                isAttacked = false;
                attackTime = 0f;
            }
        }
    }
}
