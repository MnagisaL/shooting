using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersBallet : BaseBallet
{

    private bool tests;

    protected override void Update()
    {
        base.Update();
        BalletMoving(m_GunSpeed);
    }

    protected override void BalletMoving(float speed)
    {
        //�Ƃ肠�����܂������i��
        Vector3 balletPos = transform.position;
        float x = speed * Time.deltaTime;
        this.transform.position += new Vector3(x, 0, 0);
    }


}
