using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController
{
    public CircleCollider2D feetCollider = null;
    public LayerMask groundLayer;
    public int jumpTime = 2;
    public float jumpPower = 12;
    private int _jumpTime = 0;
    //是否是着陆状态
    private bool isGrounded = false;

    private void CheckJump()
    {
        isGrounded = GetGrounded();
        if (Input.GetButtonDown(GameGlobal.jumpButton))
        {
            Jump();
        }
            
    }


    //检查是否着陆
    protected bool GetGrounded()
    {

        //获取脚部collider的中心点
        Vector2 circleCenter = new Vector2(feetCollider.transform.position.x, feetCollider.transform.position.y);
        //获取脚部collider交错着的其他collider
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(circleCenter, feetCollider.radius, groundLayer);
        //如果没有碰撞器在区域内，就会返回一个空的数组
        //着陆
        if (hitColliders.Length > 0)
        {
            return true;
            
        } 
        return false;
    }

    protected void Jump()
    {
        if (isGrounded)
        {
            _jumpTime = jumpTime;
            
        }
        if (_jumpTime <= 0) return;


        _jumpTime--;
        //thisBody.AddForce(Vector2.up * jumpPower);
        thisBody.velocity = Vector2.up * jumpPower;
    }
}
