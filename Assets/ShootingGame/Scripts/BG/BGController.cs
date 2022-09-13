using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 背景の操作　
/// ループ処理
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

    //スピードの分動かす
    private void BG_Moving()
    {
        this.transform.Translate(scrollSpeed, 0, 0);
    }

    //デットラインを超えたら元の位置に戻す
    private void Position_Reset()
    {
        if (transform.position.x < deadLine)
        {
            transform.position = new Vector3(startLine, 0, 0);
        }
    }

}
