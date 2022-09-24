using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�e���g�ɕt����
public class BaseBallet : MonoBehaviour
{
    //�G�ɗ^����_���[�W
    [SerializeField]
    protected float m_GunDamage;

    //�e�̃X�s�[�h
    [SerializeField]
    protected float m_GunSpeed;

    private StagesRange stagesRange = new StagesRange();

    protected virtual void Update()
    {
        IsOutStagesThisBallet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�_���[�W�C���^�[�t�F�[�X�������Ă��Ȃ������珈����ʂ��Ȃ�
        if (collision.gameObject.GetComponent<IDamageable>() == null) return;
        collision.gameObject.GetComponent<IDamageable>().DamageAble(m_GunDamage);
        Destroy(this.gameObject);
    }

    //�e�̓������Ǘ�
    protected virtual void BalletMoving(float speed)
    {

    }

    private void IsOutStagesThisBallet()
    {
        //�]�T����������K�v�����邩��
        if (stagesRange.IsOverStagesPosition(this.transform))
            Destroy(this.gameObject);
    }

}
