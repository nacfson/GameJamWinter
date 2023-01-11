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
    public float yPower = 2.0f;

    public GameObject startZone;

    private void Awake() 
    {
        deadZoneCollision = FindObjectOfType<DeadZoneCollision>();
        startZone = FindObjectOfType<StartZoneCollision>().gameObject;
        xPower = 0.4f;
        _tapPanel.SetActive(true);
        startZone.SetActive(true);
    }

    public void OnButton()
    {
        playerController ??= FindObjectOfType<PlayerController>();

            GameManager.canMove = true;
            GameManager.canSpawn = true;

        _tapPanel.SetActive(false);
        startZone.SetActive(false);
        Vector2 dir = new Vector2(xPower,yPower);
        playerController.WallJump(dir);
    }
}
