using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Rigidbody), typeof(BoxCollider))]
public class AnimalController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private FloatingJoystick _joystick;
    [SerializeField] private Animator _animator;


    [SerializeField] private float _moveSpeed;

    private void FixedUpdate()
    {

        //_rigidBody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidBody.velocity.y*0, _joystick.Vertical * _moveSpeed);

        Vector3 direction = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidBody.velocity.y * 0, _joystick.Vertical * _moveSpeed);

        _rigidBody.velocity = direction;

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidBody.velocity);
            _animator.SetBool("run", true);
            
        }
        else
        {
            _animator.SetBool("run", false);
            
        }
            

    }
}
