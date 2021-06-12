using System;
using System.Collections;
using UnityEditorInternal;
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
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    
    private InputController _input;

    private void Awake()
    {   
        _input = new InputController();
        _input.Player.Jump.performed += context => jump();
        _playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => _input.Enable();
    private void OnDisable() => _input.Disable();

    private void Update()
    {
        if (_input.Player.Move.ReadValue<Vector2>()!=Vector2.zero && IsGrounded())
        {
            move(_input.Player.Move.ReadValue<Vector2>());
        }
    }
    private void move(Vector2 moveDirection)
    {
        transform.position += transform.right * moveDirection.x * moveSpeed * Time.deltaTime;
        _playerSprite.flipX = moveDirection.x > 0 ? true : false;
    }

    private void jump()
    {
        if (IsGrounded())
        {
            float moveX = (_input.Player.Move.ReadValue<Vector2>().x) * moveSpeed;
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX,jumpForce);
        }
    }

    private bool IsGrounded()
    {
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