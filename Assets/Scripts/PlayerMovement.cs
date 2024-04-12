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
