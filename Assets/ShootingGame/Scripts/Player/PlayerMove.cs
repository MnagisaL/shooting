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

    private CurrentPlayerMove CurrentPlayerMove = new CurrentPlayerMove();
    DecelerationPlayer decelerationPlayer;

    private StagesRange stagesRange=new StagesRange();


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
        if (stagesRange.IsOutStageObjDown(this.transform))
        {
            playerPos.y = stagesRange.GetMaxDown() + 0.001f;
        }
        else if (stagesRange.IsOutStageObjUp(this.transform))
        {
            playerPos.y = stagesRange.GetMaxUP() - 0.001f;
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
        if (stagesRange.IsOutStageObjLeft(this.transform))
        {
            playerPos.x = stagesRange.GetMaxLEFT() + 0.001f;
        }
        else if (stagesRange.IsOutStageObjRight(this.transform))
        {
            playerPos.x = stagesRange.GetMaxRIGHT() - 0.001f;
        }
        else
        {
            playerPos.x += decelerationPlayer.DecelerationRatio(playerSpeed) * Time.deltaTime;
        }
        this.transform.position = playerPos;
    }


}
