using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの動きの状態把握
/// </summary>
public class CurrentPlayerMove 
{

    public enum MoveTypeY
    {
        Default,
        UP,
        DOWN,
    }

    private MoveTypeY moveTypeY;

    public enum MoveTypeX
    {
        Default,
        Right,
        LEFT
    }

    private MoveTypeX moveTypeX;

    public MoveTypeY GetMoveTypeY()
    {
        return moveTypeY;
    }

    public MoveTypeX GetMoveTypeX()
    {
        return moveTypeX;
    }

    public void Init()
    {
        moveTypeY = MoveTypeY.Default;
        moveTypeX = MoveTypeX.Default;
    }

    //キー入力に対してMoveTypeを分ける。
    public void PlayerMove()
    {
        PlayerDefaultMoveY();
        PlayerDefaultMoveX();
        PlayerUpMove();
        PlayerDownMove();
        PlayerRightMove();
        PlayerLeftMove();
    }

    private void PlayerDefaultMoveY()
    {
        if (Input.GetAxisRaw("Vertical") == 0 )
            moveTypeY = MoveTypeY.Default;
    }

    private void PlayerUpMove()
    {
        if (Input.GetAxisRaw("Vertical") > 0)
            moveTypeY = MoveTypeY.UP;
    }

    private void PlayerDownMove()
    {
        if (Input.GetAxisRaw("Vertical") < 0)
            moveTypeY = MoveTypeY.DOWN;
    }

    private void PlayerDefaultMoveX()
    {
        if (Input.GetAxisRaw("Horizontal") == 0)
            moveTypeX = MoveTypeX.Default;
    }

    private void PlayerRightMove()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
            moveTypeX = MoveTypeX.Right;
    }

    private void PlayerLeftMove()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
            moveTypeX = MoveTypeX.LEFT;
    }

}
