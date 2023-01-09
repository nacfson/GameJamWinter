using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int JumpCount
    {
        get => _jumpCount;
        set => _jumpCount = value;
    }
    public Rigidbody2D rigid;
    [SerializeField]
    private float _xSpeed  =1f;
    [SerializeField]
    private float _jumpPower = 0.5f;

    public bool isWall;
    public bool isLeftWall;
    public bool isRightWall;
    private int _jumpCount;
    private void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        _jumpCount = 1;
    }
    
    
    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveVec = new Vector2(x *_xSpeed ,rigid.velocity.y);
        rigid.velocity = moveVec;
    }
    public bool MinusJumpCount(int plus)
    {
        _jumpCount += plus;

        if(_jumpCount < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public void WallJump(Vector2 dir)
    {
        if(MinusJumpCount(-1))
        {
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(dir * _jumpPower * 200);
        }
        Debug.Log("Jump");
    }
}
