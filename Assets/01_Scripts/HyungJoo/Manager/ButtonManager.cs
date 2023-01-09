using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public PlayerController playerController;


    public float xPower = 0.5f;
    public float yPower = 1f;

    private void Awake() 
    {
        playerController = FindObjectOfType<PlayerController>();
        xPower = 0.5f;
    }
    public void OnButton()
    {
        Debug.Log("OnButton");
        Vector2 dir = new Vector2(xPower,yPower);
        playerController.WallJump(dir);
        Debug.Log(xPower);

    }
    private void Update() {
    }


}
