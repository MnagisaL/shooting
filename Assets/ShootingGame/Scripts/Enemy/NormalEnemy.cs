using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : BaseEnemy
{
    public override void DamageAble(float damage)
    {
        HP -= damage;
        if (HP < 0)
        {
            Destroy(this.gameObject);
        }
    }

}
