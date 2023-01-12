using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class PlayerController : MonoBehaviour
{
    public int JumpCount
    {
        get => _jumpCount;
        set => _jumpCount = value;
    }
    Animator anim;

    public Rigidbody2D rigid;
    [SerializeField]
    private float _xSpeed  =1f;
    [SerializeField]
    private float _jumpPower = 0.5f;

    public bool isWall;
    public bool isLeftWall;
    public bool isRightWall;
    private int _jumpCount;
    public UnityEvent Jumped;
    public  AudioSource jumpSound;
    public AudioSource deadSound;
    public bool canSave;
    public Vector2 moveVec;
    public EffectManager effectManager;
    public Action shieldAction;
    public static bool onShield;

   
    private void Awake() 
    {
        
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        effectManager = FindObjectOfType<EffectManager>();
        _jumpCount = 1;
        shieldAction+= DoShield;

    }
    private void Start() {
        GameManager.Instance.PlayerDead = null;
        GameManager.Instance.PlayerDead -= () => DieProcess();
        GameManager.Instance.PlayerDead += () => DieProcess();
        canSave  = true;
    }

    private void Update()
    {
        if(isWall == false)
        {
            anim.SetBool("Pwall", false);
        }
    }
    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
         moveVec = new Vector2(x *_xSpeed ,rigid.velocity.y);
        rigid.velocity = moveVec;
    }
    public bool MinusJumpCount(int plus)
    {
        _jumpCount += plus;
        if(_jumpCount < 0)
        {

            return false;

        }
        else
        {

            return true;
        }

    }
    public void WallJump(Vector2 dir)
    {
        if(MinusJumpCount(-1))
        {
            anim.SetBool("Pwall",false);
            anim.SetTrigger("Fjump");
            rigid.velocity = new Vector2(0,0);
            rigid.AddForce(dir * _jumpPower * 200);
            Jumped?.Invoke();
            jumpSound?.Play();
            effectManager.InstantiateJumpEffect();
            

        }
        if(JumpCount == 0)
        {
            anim.SetBool("Pwall", false);
            anim.SetTrigger("Sjump");

            effectManager.InstantiateJumpEffect();

        }
        
        
    }

    public void DieProcess()
    {

        GameManager.Instance.PlayerDead -= DieProcess;
        rigid.gravityScale = 0f;
        rigid.velocity = Vector3.zero;
        Debug.Log("DieProcess");
        anim = GetComponent<Animator>();
        anim.SetTrigger("Die");
        deadSound?.Play();
        GameManager.Instance.PlayPlayerDead();
    }

    public void Destruction()
    {
        GameManager.Instance.PlayerAnimationEnd?.Invoke();
        //gameObject.SetActive(false);
    }
    public void DoShield()
    {
        onShield = true;
    }
}
