using System;
using Managers;
using UI;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using PlayerInput = InputScripts.PlayerInput;

public class PlayerController : MonoBehaviour , PlayerInput.IPlayerActions
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    private PlayerInput _playerInput;
    private Vector2 _direction;
    private float _moveSpeed = 5f;
    private float _jumpForce = 5f;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.SetCallbacks(this);
        _playerInput.Enable();
        _playerInput.Player.Shot.started += (context =>
        {
            Instantiate(bullet, transform.position, quaternion.identity);
        });
        
    }

    private bool isOpen;
    private void Update()
    {
        Vector2 movement = new Vector2(_direction.x * _moveSpeed, rb.velocity.y);
        rb.velocity = movement;
        if (_direction.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, _jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (isOpen)
            {
                UIManager.Instance.CloseUI<UIStatus>();
            }
            else
            {
                UIManager.Instance.OpenUI<UIStatus>();
            }
            isOpen = !isOpen;
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            UIManager.Instance.OpenUI<UIStagePopup>();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
    }

    public void OnShot(InputAction.CallbackContext context) { }
}
