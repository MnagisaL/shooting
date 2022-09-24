using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージの外に出ることが予想され,
/// そのときに処理が必要なものに必要なクラス
/// </summary>
/// 

public class StagesRange
{
    private const float MAXUP = 4.6f;
    private const float MAXDOWN = -4.92f;
    private const float MAXLEFT = -8.5f;
    private const float MAXRIGHT = 8.85f;

    /// <param name="objTransform"></param>オブジェクトのトランスフォーム
    /// <param name="adjustRange"></param>もしも余白が欲しかったら使う
    /// <returns></returns>
    public bool IsOutStageObjUp(Transform objTransform, float adjustRange = 0)
    {
        return objTransform.position.y > MAXUP + adjustRange;
    }

    public bool IsOutStageObjDown(Transform objTransform, float adjustRange = 0)
    {
        return objTransform.position.y < MAXDOWN - adjustRange;
    }

    public bool IsOutStageObjRight(Transform objTransform, float adjustRange = 0)
    {
        return objTransform.position.x > MAXRIGHT - adjustRange;
    }

    public bool IsOutStageObjLeft(Transform objTransform, float adjustRange = 0)
    {
        return objTransform.position.x < MAXLEFT - adjustRange;
    }

    //どこかしらが出ていた時の判定
    public bool IsOverStagesPosition(Transform objTransform, float adjustRange = 0)
    {
        return
               IsOutStageObjUp(objTransform, adjustRange)
            || IsOutStageObjDown(objTransform, adjustRange)
            || IsOutStageObjRight(objTransform, adjustRange)
            || IsOutStageObjLeft(objTransform, adjustRange);
    }

    public float GetMaxUP()
    {
        return MAXUP;
    }

    public float GetMaxDown()
    {
        return MAXDOWN;
    }

    public float GetMaxLEFT()
    {
        return MAXLEFT;
    }
    public float GetMaxRIGHT()
    {
        return MAXRIGHT;
    }

}
