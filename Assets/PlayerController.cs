using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset playerControls;
    private Vector2 movementInput = Vector2.zero;

    [SerializeField]
    public float speed = 6;
    private void Awake()
    {
        InputActionMap playerMap = playerControls.FindActionMap("Player");

        InputAction shootAction = playerMap.FindAction("Shoot");
        shootAction.performed += (ctx) => { Shoot(); };

        InputAction moveAction = playerMap.FindAction("Move");
        moveAction.performed += (ctx) => { movementInput = ctx.ReadValue<Vector2>(); };
        moveAction.canceled += (ctx) => { movementInput = Vector2.zero; };
        playerMap.Enable();

    }

    private void Update()
    {
        Move(movementInput, Time.deltaTime);
    }

    public void Move(Vector2 _Direction, float _DeltaTime)
    {
        _Direction.Normalize();
        Vector3 movement = new Vector3(_Direction.x, 0f, _Direction.y);
        transform.position += movement * speed * _DeltaTime;
        Debug.DrawRay(transform.position, _Direction, Color.cyan, .2f);
    }
    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}

