using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public PlayerController playerController;

    public DeadZoneCollision deadZoneCollision;
    public float xPower = 0.4f;
    public float yPower = 2.0f;

    private void Awake() 
    {
        deadZoneCollision = FindObjectOfType<DeadZoneCollision>();
        playerController = FindObjectOfType<PlayerController>();
        xPower = 0.4f;
        GameManager.Instance.canMove = false;
    }

    public void OnButton()
    {


            GameManager.Instance.canMove = true;


            Vector2 dir = new Vector2(xPower,yPower);
            playerController.WallJump(dir);
        


    }



}
