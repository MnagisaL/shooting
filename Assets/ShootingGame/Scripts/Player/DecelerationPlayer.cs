using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������������N���X�B
/// </summary>
public class DecelerationPlayer
{

    private float m_Deceleration;

    public DecelerationPlayer(float deceleration)
    {
        m_Deceleration = deceleration;
    }

    //�V�t�g���������猸�����Ƌ��ɃX�s�[�h�ύX
    public float DecelerationRatio(float speed)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= m_Deceleration;
        }
        return speed;
    }

    //������
    public bool IsStayDeceleration()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

}
