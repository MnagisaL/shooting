using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �v���C���[�̓���
/// �s���͈͂̐���
/// shift�Ō�������
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
        //deceleration�̃C���X�^���X����
        decelerationPlayer = new DecelerationPlayer(deceleration);
        CurrentPlayerMove.Init();
    }

    void LateUpdate()
    {
        CurrentPlayerMove.PlayerMove();
        PlayerMovingY();
        PlayerMovingX();
    }

    //Y���̓����̊Ǘ�
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

    //X���̓����̊Ǘ�
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

    //�V�t�g�������ƌ�������@�c���̊Ǘ�
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

    //�����̊Ǘ�
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
