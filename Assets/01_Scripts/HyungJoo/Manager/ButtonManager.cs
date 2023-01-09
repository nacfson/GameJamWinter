using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public PlayerController playerController;


    public float xPower = 0.4f;
    public float yPower = 2.0f;

    private void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
        xPower = 0.4f;
    }
    public void OnButton()
    {
        Debug.Log("OnButton");
        Vector2 dir = new Vector2(xPower,yPower);
        playerController.WallJump(dir);

    }



}
