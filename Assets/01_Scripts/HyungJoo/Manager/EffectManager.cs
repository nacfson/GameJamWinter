using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _jumpEffect;
    private Transform _applyTransform;
    [SerializeField]
    private GameObject _deadEffect;

    void Start()
    {
        GameManager.Instance.PlayerDead += InstantiateDeadEffect;
    }

    public void InstantiateDeadEffect()
    {        
        if(_applyTransform == null)
        {
            _applyTransform = FindObjectOfType<PlayerController>().transform.Find("JumpEffectPivot");
        }
        GameObject obj = Instantiate(_deadEffect,_applyTransform);
        Debug.Log("InstantiateDeadEffecct");

        obj.transform.SetParent(null);
        obj.GetComponent<ParticleSystem>().Play();

    }


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
