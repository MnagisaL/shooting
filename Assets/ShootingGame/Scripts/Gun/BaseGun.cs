using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e���g�ɕt����
public abstract class BaseGun : MonoBehaviour
{
    //�G�ɗ^����_���[�W
    public float m_GunDamage { private get; set; }

    //�e�̊Ԋu
    public float m_GunInterval { private get; set; }

    //�e�̃X�s�[�h
    public float m_GunSpeed { private get; set; }

    //�G�ɂ����������̏����A�_���[�W����
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    protected virtual void GunMoving(float speed)
    { 
    
    }

}
