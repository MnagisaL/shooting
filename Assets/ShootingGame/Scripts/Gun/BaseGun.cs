using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//弾自身に付ける
public abstract class BaseGun : MonoBehaviour
{
    //敵に与えるダメージ
    public float m_GunDamage { private get; set; }

    //弾の間隔
    public float m_GunInterval { private get; set; }

    //弾のスピード
    public float m_GunSpeed { private get; set; }

    //敵にあたった時の処理、ダメージ処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    protected virtual void GunMoving(float speed)
    { 
    
    }

}
