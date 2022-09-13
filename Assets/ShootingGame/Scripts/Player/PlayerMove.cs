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

    //������͈�  �̂��̂��ŏ��Ɏ擾�ł���悤�ɂ���
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

    private void Init()
    {
        //������͈͂̏����ݒ�
        //MaxUp = Screen.height / 2;
        //MaxDown = -Screen.height / 2;
        //MaxRight = Screen.width / 2;
        //MaxLeft = -Screen.width / 2;
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

    //�����̊Ǘ�
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

    //Player����O�ɍs�����ꍇ
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
