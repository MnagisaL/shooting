using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �w�i�̑���@
/// ���[�v����
/// </summary>
public class BGController : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private float startLine;
    [SerializeField]
    private float deadLine;

    void LateUpdate()
    {
        BG_Moving();
        Position_Reset();
    }

    //�X�s�[�h�̕�������
    private void BG_Moving()
    {
        this.transform.Translate(scrollSpeed, 0, 0);
    }

    //�f�b�g���C���𒴂����猳�̈ʒu�ɖ߂�
    private void Position_Reset()
    {
        if (transform.position.x < deadLine)
        {
            transform.position = new Vector3(startLine, 0, 0);
        }
    }

}
