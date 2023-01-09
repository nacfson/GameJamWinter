using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _jumpEffect;
    private Transform _applyTransform;


    public void InstantiateJumpEffect()
    {
        if(_applyTransform == null)
        {
            _applyTransform = FindObjectOfType<PlayerController>().transform.Find("JumpEffectPivot");
        }
        GameObject obj = Instantiate(_jumpEffect,_applyTransform);
        obj.transform.SetParent(null);

    }
}