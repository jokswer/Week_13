using System;
using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    private static readonly int IsRun = Animator.StringToHash("IsRun");

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Joystick _joystick;
    private Vector2 _moveInput;

    private void Update()
    {
        _moveInput = _joystick.Value;
        _animator.SetBool(IsRun, _joystick.IsPressed);
    }

    private void FixedUpdate()
    {
        SetVelocity();

        if (_rigidbody.velocity != Vector3.zero)
            SetRotation();
    }

    private void SetRotation()
    {
        transform.rotation = Quaternion.LookRotation(_rigidbody.velocity, Vector3.up);
    }

    private void SetVelocity()
    {
        _rigidbody.velocity = new Vector3(_moveInput.x, 0, _moveInput.y) * _speed;
    }
}