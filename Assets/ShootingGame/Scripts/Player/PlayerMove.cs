using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// プレイヤーの動き
/// 行動範囲の制御
/// shiftで減速処理
/// </summary>

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private float playerSpeedY;
    [SerializeField]
    private float playerSpeedX;
    [SerializeField]
    private float deceleration;

    //動ける範囲  のちのち最初に取得できるようにする
    [SerializeField]
    private float MaxUp;
    [SerializeField]
    private float MaxDown;
    [SerializeField]
    private float MaxLeft;
    [SerializeField]
    private float MaxRight;

    private CurrentPlayerMove CurrentPlayerMove = new CurrentPlayerMove();
    DecelerationPlayer decelerationPlayer;


    private void Awake()
    {
        //decelerationのインスタンス生成
        decelerationPlayer = new DecelerationPlayer(deceleration);
        CurrentPlayerMove.Init();
    }

    void LateUpdate()
    {
        CurrentPlayerMove.PlayerMove();
        PlayerMovingY();
        PlayerMovingX();
    }

    private void Init()
    {
        //動ける範囲の初期設定
        //MaxUp = Screen.height / 2;
        //MaxDown = -Screen.height / 2;
        //MaxRight = Screen.width / 2;
        //MaxLeft = -Screen.width / 2;
    }


    //Y軸の動きの管理
    private void PlayerMovingY()
    {
        switch (CurrentPlayerMove.GetMoveTypeY())
        {
            case CurrentPlayerMove.MoveTypeY.UP:
                PlayerMoving_CalcY(playerSpeedY);
                break;
            case CurrentPlayerMove.MoveTypeY.DOWN:
                PlayerMoving_CalcY(-playerSpeedY);
                break;
            case CurrentPlayerMove.MoveTypeY.Default:
                break;
        }
    }

    //X軸の動きの管理
    private void PlayerMovingX()
    {
        switch (CurrentPlayerMove.GetMoveTypeX())
        {
            case CurrentPlayerMove.MoveTypeX.Right:
                PlayerMoving_CalcX(playerSpeedX);
                break;
            case CurrentPlayerMove.MoveTypeX.LEFT:
                PlayerMoving_CalcX(-playerSpeedX);
                break;
            case CurrentPlayerMove.MoveTypeX.Default:
                break;
        }
    }

    //シフトを押すと減速する　縦軸の管理
    private void PlayerMoving_CalcY(float playerSpeed)
    {
        Vector3 playerPos = this.transform.position;
        if (IsOutPlayerDown())
        {
            playerPos.y = MaxDown + 0.001f;
        }
        else if (IsOutPlayerUp())
        {
            playerPos.y = MaxUp - 0.001f;
        }
        else
        {
            playerPos.y += decelerationPlayer.DecelerationRatio(playerSpeed) * Time.deltaTime;
        }
        this.transform.position = playerPos;
    }

    //横軸の管理
    private void PlayerMoving_CalcX(float playerSpeed)
    {
        Vector3 playerPos = this.transform.position;
        if (IsOutPlayerLeft())
        {
            playerPos.x = MaxLeft + 0.001f;
        }
        else if (IsOutPlayerRight())
        {
            playerPos.x = MaxRight - 0.001f;
        }
        else
        {
            playerPos.x += decelerationPlayer.DecelerationRatio(playerSpeed) * Time.deltaTime;
        }
        this.transform.position = playerPos;
    }

    //Playerが場外に行った場合
    private bool IsOutPlayerUp()
    {
        return this.transform.position.y > MaxUp;
    }

    private bool IsOutPlayerDown()
    {
        return this.transform.position.y < MaxDown;
    }

    private bool IsOutPlayerLeft()
    {
        return this.transform.position.x < MaxLeft;
    }

    private bool IsOutPlayerRight()
    {
        return this.transform.position.x > MaxRight;
    }


}
