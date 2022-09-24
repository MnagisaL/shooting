using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField]
    private GameObject Ballet;
    [SerializeField]
    private float interVal;

    async void Start()
    {
        await GunShot(interVal);
    }

    private async UniTask GunShot(float interval)
    {
        //�����ɒe���o��������B
        //�e���o���Ȃ��^�C�~���O�͂����Ō��߂�B
        while (true)
        {
            await UniTask.WaitUntil(() => Input.GetKey(KeyCode.Z));
            Instantiate(Ballet, this.transform.position, Quaternion.identity);
            await UniTask.Delay(TimeSpan.FromSeconds(interval));
        }
    }

}
