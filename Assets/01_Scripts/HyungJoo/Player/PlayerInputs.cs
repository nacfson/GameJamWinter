using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour
{
    public UnityEvent JumpButtonClicked;

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            JumpButtonClicked?.Invoke();
        }
    }

}
