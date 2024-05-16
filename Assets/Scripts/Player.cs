using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _moveVector;
    public static GameObject Instance;
    [SerializeField] private float moveSpeed = 5f;
    private Animator _animator;
    private static readonly int Horizontal1 = Animator.StringToHash("Horizontal");
    private static readonly int Vertical1 = Animator.StringToHash("Vertical");
    private static readonly int LastHorizontal1 = Animator.StringToHash("LastHorizontal");
    private static readonly int LastVertical1 = Animator.StringToHash("LastVertical");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (Instance != null)
            Debug.LogWarning("Found more than one player in the scene");
        Instance = gameObject;
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        CustomInputInitializer.CustomInput.Player.Movement.performed += OnMovementPerformed;
        CustomInputInitializer.CustomInput.Player.Movement.canceled += OnMovementCanceled;
    }

    private void FixedUpdate()
    {
        _animator.SetFloat(Horizontal1, _rb.velocity.x);
        _animator.SetFloat(Vertical1, _rb.velocity.y);
        if (_moveVector.x != 0 || _moveVector.y != 0)
        {
            _animator.SetFloat(LastHorizontal1, _moveVector.x);
            _animator.SetFloat(LastVertical1, _moveVector.y);
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

    public bool CheckVelocity() => _rb.velocity != Vector2.zero;

    public void InteractCompleted(string item)
    {
        switch (item)
        {
            case "candle":
                CandleInteractCompleted?.Invoke();
                break;
            case "salt":
                SaltInteractCompleted?.Invoke();
                break;
            case "knife":
                KnifeInteractCompleted?.Invoke();
                break;
            case "crucifix":
                CrucifixInteractCompleted?.Invoke();
                break;
            case "icon":
                IconInteractCompleted?.Invoke();
                break;
            case "chalk":
                ChalkInteractCompleted?.Invoke();
                break;
            case "incense":
                IncenseInteractCompleted?.Invoke();
                break;
            case "herbs":
                HerbsInteractCompleted?.Invoke();
                break;
        }
    }

    public event Action CandleInteractCompleted;
    public event Action SaltInteractCompleted;

    public event Action KnifeInteractCompleted;
    public event Action CrucifixInteractCompleted;
    public event Action IconInteractCompleted;
    public event Action ChalkInteractCompleted;
    public event Action HerbsInteractCompleted;
    public event Action IncenseInteractCompleted;
}