using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������]�����
public class GunPoint : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    private float direction = 1.0f;

    //�ړ����x�Ƃ������ړ��p�x�B
    [SerializeField]
    private float gunSpeed = 3.0f;

    //�v���C���[��ǔ����鑬�x�̃��[�g(�傫��������)�B
    [SerializeField]
    private float followRate = 0.1f;

    //�ǔ�����|�C���g�̃v���C���[����̋���(�܂菬�������A�ߕt��)�B
    [SerializeField]
    float followTargetDistance = 5.0f;

    void FixedUpdate()
    {
        //�v���C���[�����̋����Œǔ��B
        this.transform.position = Vector3.Lerp(this.transform.position, playerPos.position + (this.transform.position - playerPos.transform.position).normalized * followTargetDistance, followRate);
        //�v���C���[�𒆐S�ɉ~�^���B
        this.transform.RotateAround(playerPos.position, Vector3.forward, direction * gunSpeed);
    }

}
