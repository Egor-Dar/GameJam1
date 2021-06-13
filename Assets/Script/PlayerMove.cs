using System;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
[Header("для проверки соприкосновения с землей")] [SerializeField]
    private bool DrawBox;
    [SerializeField] private Transform graundCheckTransform;
    [SerializeField] private Vector2 boxSize;
    [SerializeField] private LayerMask mask;


    [Header("Player settings")]
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    [Space]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    [Space] [Tooltip("объект с котиком")] [SerializeField]
    private GameObject catObject;
    
    private InputController _input;
    private Animator anim, animCat;
    
    private void Awake()
    {   
        _input = new InputController();
        anim = GetComponent<Animator>();
        animCat = catObject.GetComponent<Animator>();
        _input.Player.Jump.performed += context => jump();
        _playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

    private void Update()
    {
        animCat.SetBool("isGround",IsGrounded());
        animCat.SetFloat("velosity", rb.velocity.y);
        
        if (!IsGrounded() && (rb.velocity.y < -0.5f || rb.velocity.y > 0.5f))
        {
            SwitchCat(true);
            animCat.SetTrigger("fall");
        }
        
        if (_input.Player.Move.ReadValue<Vector2>()!=Vector2.zero && IsGrounded())
        {
            move(_input.Player.Move.ReadValue<Vector2>());
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }

        if (rb.velocity.y <= -50)
        {
            GetComponent<PlayerSound>().FallingSound(true);
        }
    }
    private void move(Vector2 moveDirection)
    {
        transform.position += transform.right * moveDirection.x * moveSpeed * Time.deltaTime;
        _playerSprite.flipX = moveDirection.x > 0 ? false : true;
    }

    private void jump()
    {
        if (IsGrounded())
        {
            GetComponent<PlayerSound>().JumpSound();
            SwitchCat(true);
            animCat.SetBool("jump",true);
            float moveX = (_input.Player.Move.ReadValue<Vector2>().x) * moveSpeed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX,jumpForce);
        }
    }

    public void Die()
    {
        SwitchCat(true);
        animCat.SetTrigger("die");
    }

    public void GameOver()
    {
        DieManager.Die();
    }

    public void SwitchCat(bool cat)
    {
        switch (cat)
        {
            case true:
                catObject.SetActive(true);
                GetComponent<SpriteRenderer>().enabled = false;
                _boxCollider2D.offset = new Vector2(0.7560744f, -9.075159f);
                _boxCollider2D.size = new Vector2(9.152547f, 13.79865f);
                break;
            case false:
                catObject.SetActive(false);
                GetComponent<SpriteRenderer>().enabled = true;
                _boxCollider2D.offset = new Vector2(0.7560744f, 0.1931362f);
                _boxCollider2D.size = new Vector2(9.152547f, 32.33524f);
                break;
        }
    }
    
    private bool IsGrounded()
    {
        GetComponent<PlayerSound>().FallingSound(false);
        return Physics2D.OverlapBox(graundCheckTransform.position, boxSize, 0f, mask) ? true : false;
    }

    
    void OnDrawGizmos()
    {
        if (DrawBox)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(graundCheckTransform.position, boxSize);
        }
    }
}