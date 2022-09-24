using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�e�[�W�̊O�ɏo�邱�Ƃ��\�z����,
/// ���̂Ƃ��ɏ������K�v�Ȃ��̂ɕK�v�ȃN���X
/// </summary>
/// 

public class StagesRange
{
    private const float MAXUP = 4.6f;
    private const float MAXDOWN = -4.92f;
    private const float MAXLEFT = -8.5f;
    private const float MAXRIGHT = 8.85f;

    /// <param name="objTransform"></param>�I�u�W�F�N�g�̃g�����X�t�H�[��
    /// <param name="adjustRange"></param>�������]�����~����������g��
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

    //�ǂ������炪�o�Ă������̔���
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
