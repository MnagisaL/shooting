using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//弾自身に付ける
public class BaseBallet : MonoBehaviour
{
    //敵に与えるダメージ
    [SerializeField]
    protected float m_GunDamage;

    //弾のスピード
    [SerializeField]
    protected float m_GunSpeed;

    private StagesRange stagesRange = new StagesRange();

    protected virtual void Update()
    {
        IsOutStagesThisBallet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ダメージインターフェースを持っていなかったら処理を通さない
        if (collision.gameObject.GetComponent<IDamageable>() == null) return;
        collision.gameObject.GetComponent<IDamageable>().DamageAble(m_GunDamage);
        Destroy(this.gameObject);
    }

    //弾の動きを管理
    protected virtual void BalletMoving(float speed)
    {

    }

    private void IsOutStagesThisBallet()
    {
        //余裕を持たせる必要があるかも
        if (stagesRange.IsOverStagesPosition(this.transform))
            Destroy(this.gameObject);
    }

}
