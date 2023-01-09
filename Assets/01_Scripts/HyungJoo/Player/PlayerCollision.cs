using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController playerController;
    public ButtonManager buttonManager;
    void Awake()
    {
        playerController = GetComponent<PlayerController>();
        buttonManager = FindObjectOfType<ButtonManager>();
    }
    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("LeftWall"))
        {
            playerController.isWall = true;
            playerController.JumpCount  = 2;
            playerController.isLeftWall = true;
            playerController.rigid.gravityScale = 0.2f;
            buttonManager.xPower = 0.7f;
        }
        if(other.gameObject.CompareTag("RightWall"))
        {
            playerController.isWall = true;
            playerController.JumpCount  = 2;
            playerController.isRightWall = true;
            playerController.rigid.gravityScale = 0.2f;
            buttonManager.xPower = -0.7f;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("LeftWall"))
        {
            playerController.isWall = false;
            playerController.rigid.gravityScale = 1f;
        }
        if(other.gameObject.CompareTag("RightWall"))
        {
            playerController.isWall = false;
            playerController.rigid.gravityScale = 1f;
        }
    }
}
