using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour ,IDamageable
{
    [SerializeField]
    protected float HP = 0;
    public virtual void DamageAble(float damage) 
    {
      
    }

}
