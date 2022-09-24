using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//周りを回転するよ
public class GunPoint : MonoBehaviour
{
    [SerializeField]
    private Transform playerPos;

    private float direction = 1.0f;

    //移動速度というか移動角度。
    [SerializeField]
    private float gunSpeed = 3.0f;

    //プレイヤーを追尾する速度のレート(大きい程高速)。
    [SerializeField]
    private float followRate = 0.1f;

    //追尾するポイントのプレイヤーからの距離(つまり小さい程、近付く)。
    [SerializeField]
    float followTargetDistance = 5.0f;

    void FixedUpdate()
    {
        //プレイヤーを一定の距離で追尾。
        this.transform.position = Vector3.Lerp(this.transform.position, playerPos.position + (this.transform.position - playerPos.transform.position).normalized * followTargetDistance, followRate);
        //プレイヤーを中心に円運動。
        this.transform.RotateAround(playerPos.position, Vector3.forward, direction * gunSpeed);
    }

}
