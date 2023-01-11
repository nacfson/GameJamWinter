using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject player;

    public List<Animator> animatorList = new List<Animator>();
    private void Start() {
        player = FindObjectOfType<PlayerController>().gameObject;
        switch(PlayerPrefs.GetInt("APPLYCOUNT"))
        {
            case 0:
                player.GetComponent<Animator>().runtimeAnimatorController = animatorList[0].runtimeAnimatorController;
                break;  
            case 1:
                player.GetComponent<Animator>().runtimeAnimatorController = animatorList[1].runtimeAnimatorController;
                break;
        }
    }
}
