using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private Transform _playerTransform;
    public static CameraMovement Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Two camera movement in the scene");
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
            MoveToPosition(new Vector2(1, 1), 0.5f);
        if (Input.GetKeyDown(KeyCode.G))
            RevertPosition(0.5f);
    }
    

    public void MoveToPosition(Vector2 position, float time)
    {
        StartCoroutine(ChangeValueSmooth.Change(_transform.position.x, position.x,
            value => SetCameraPosition(value, _transform.position.y), time, AnimationCurves.CameraCurve));
        StartCoroutine(ChangeValueSmooth.Change(_transform.position.y, position.y,
            value => SetCameraPosition(_transform.position.x, value), time, AnimationCurves.CameraCurve));
    }

    public void RevertPosition(float time)
    {
        MoveToPosition(_playerTransform.TransformPoint(_defaultPosition), time);
    }

    private void SetCameraPosition(float newX, float newY)
    {
        if (float.IsNaN(newX) || float.IsNaN(newY))
            return;
        var newPosition = _transform.position;
        newPosition.x = newX;
        newPosition.y = newY;
        _transform.SetPositionAndRotation(newPosition, _transform.rotation);
    }
}