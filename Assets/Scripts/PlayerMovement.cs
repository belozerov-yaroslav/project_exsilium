using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CustomInputInitializer _input;
    private Rigidbody2D _rb;
    private Vector2 _moveVector;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Animator animator;
    private static readonly int Horizontal1 = Animator.StringToHash("Horizontal");
    private static readonly int Vertical1 = Animator.StringToHash("Vertical");
    private static readonly int LastHorizontal1 = Animator.StringToHash("LastHorizontal");
    private static readonly int LastVertical1 = Animator.StringToHash("LastVertical");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.CustomInput.Enable();
        _input.CustomInput.Player.Movment.performed += OnMovementPerformed;
        _input.CustomInput.Player.Movment.canceled += OnMovementCanceled;
    }
    
    private void OnDisable()
    {
        _input.CustomInput.Disable();
        _input.CustomInput.Player.Movment.performed -= OnMovementPerformed;
        _input.CustomInput.Player.Movment.canceled -= OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        animator.SetFloat(Horizontal1, _rb.velocity.x);
        animator.SetFloat(Vertical1, _rb.velocity.y);
        if (_rb.velocity.x != 0 || _rb.velocity.y != 0)
        {
            animator.SetFloat(LastHorizontal1, _rb.velocity.x);
            animator.SetFloat(LastVertical1, _rb.velocity.y);
        }
        _rb.velocity = _moveVector * moveSpeed;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        _moveVector = value.ReadValue<Vector2>();
    }   
    
    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        _moveVector = Vector2.zero;
    }
}
