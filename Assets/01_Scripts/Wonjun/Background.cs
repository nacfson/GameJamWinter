using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Background : MonoBehaviour
{
    public PlayerController player;
    public float Rwall;
    private void Start()
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();

        if(!GameManager.canMove)
        {
            return;
        }
        if (!collision.CompareTag("Area"))
            return;
        Vector2 playerPos = player.transform.position;
        Vector2 myPos = transform.position;
        Debug.Log(Rwall);
        Rwall+= 2;
        float diffx = Mathf.Abs(playerPos.x - myPos.x);
        float diffy = Mathf.Abs(playerPos.y - myPos.y);

        Vector2 playerDir = player.moveVec;
        float dirx = playerDir.x < 0 ? -1 : 1;
        float diry = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            default:
                break;
            case "Ground":
                {
                    /*if (diffx > diffy)
                    {
                        transform.Translate(Vector2.right * dirx * 40);
                    }*/
                    if (diffx < diffy)
                    {
                        transform.Translate(Vector2.up * diry * 26f);
                        
                    }
                    
                }
                break;
        }
    }
}
