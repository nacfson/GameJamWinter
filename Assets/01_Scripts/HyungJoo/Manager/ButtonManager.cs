using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public PlayerController playerController;

    public DeadZoneCollision deadZoneCollision;
    [SerializeField]
    private GameObject _tapPanel;
    public float xPower = 0.7f;
    public float yPower = 3.0f;
    public int clickCount = 0;
    public GameObject startZone;

    private void Awake() 
    {
        deadZoneCollision = FindObjectOfType<DeadZoneCollision>();
        startZone = FindObjectOfType<StartZoneCollision>().gameObject;
        xPower = 0.4f;
        _tapPanel.SetActive(true);
        clickCount = 0;
        startZone.SetActive(true);
    }

    public void OnButton()
    {
        playerController ??= FindObjectOfType<PlayerController>();
        if(clickCount <=0 )
        {
            GameManager.canMove = true;
            GameManager.canSpawn = true;
        }
        clickCount ++;
        _tapPanel.SetActive(false);
        startZone.SetActive(false);
        Vector2 dir = new Vector2(xPower,yPower);
        if(GameManager.canMove)
        {
            playerController.WallJump(dir);
            return;
        }
    }
}
