using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    Animator anim;
    public PlayerController playerController;
    public ButtonManager buttonManager;
    SpriteRenderer sp;
    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
            
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        buttonManager = FindObjectOfType<ButtonManager>();
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("LeftWall"))
        {
            sp.flipX = false;
            anim.SetBool("Pwall", true);
            playerController.isWall = true;
            playerController.JumpCount  = 2;
            playerController.isLeftWall = true;
            playerController.rigid.gravityScale = 0f;
            buttonManager.xPower = 0.7f;
        }
        if(other.gameObject.CompareTag("RightWall"))
        {
            sp.flipX = true;
            anim.SetBool("Pwall", true);
            playerController.isWall = true;
            playerController.JumpCount  = 2;
            playerController.isRightWall = true;
            playerController.rigid.gravityScale = 0f;

            buttonManager.xPower = -0.7f;
        }
        
    }

    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("LeftWall"))
        {
            playerController.rigid.velocity = Vector3.zero;
            playerController.rigid.gravityScale = 0f;

        }
        if(other.gameObject.CompareTag("RightWall"))
        {
            playerController.rigid.velocity = Vector3.zero;
            playerController.rigid.gravityScale = 0f;

        }
    }
    
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("LeftWall"))
        {
            playerController.isWall = false;
            playerController.rigid.gravityScale = 1f;
            playerController.JumpCount--;
        }
        if(other.gameObject.CompareTag("RightWall"))
        {
            playerController.isWall = false;
            playerController.rigid.gravityScale = 1f;
            playerController.JumpCount--;
        }
    }
}
