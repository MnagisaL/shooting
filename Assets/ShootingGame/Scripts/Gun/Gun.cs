using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float amplitude=0.2f;
    [SerializeField]
    private float sinSpeed = 2f;

    private void Update()
    {
        GunMoving();
    }

    //前のオブジェクトと前の間隔を平衡に
    public void GunMoving()
    {
        Vector3 lazerPos = transform.position;
        float x = speed * Time.deltaTime;
        this.transform.position += new Vector3(x, 0, 0);
    }

}
