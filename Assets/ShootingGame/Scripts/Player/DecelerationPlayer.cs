using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 減速率を扱うクラス。
/// </summary>
public class DecelerationPlayer
{

    private float m_Deceleration;

    public DecelerationPlayer(float deceleration)
    {
        m_Deceleration = deceleration;
    }

    //シフトを押したら減速率と共にスピード変更
    public float DecelerationRatio(float speed)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed *= m_Deceleration;
        }
        return speed;
    }

    //減速中
    public bool IsStayDeceleration()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }

}
