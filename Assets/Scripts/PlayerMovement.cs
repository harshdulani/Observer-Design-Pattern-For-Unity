using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float maxMoveDelta = 0.01f;
    
    private bool _isMoving;
    private Vector3 _destination, _desiredMovementDirection;
    private float _playerY, _distanceMagnitude;

    private Ray _ray;

    private Camera _cam;
    private Rigidbody _rigidbody;
    

    private void Start()
    {
        _cam = Camera.main;
        _rigidbody = GetComponent<Rigidbody>();
        
        _playerY = transform.position.y;
    }

    private void Update()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            _ray = _cam.ScreenPointToRay(Input.mousePosition);
            _destination = Vector3.zero;
            foreach (var hit in Physics.RaycastAll(_ray))
            {
                if(hit.collider.gameObject.CompareTag("Ground"))
                    _destination = hit.point;
            }

            if (_destination != Vector3.zero)
            {
                _destination.y = _playerY;
                _isMoving = true;
            }
            else
                _isMoving = false;
        }
        else if (_isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, maxMoveDelta);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Unwalkable"))
            _isMoving = false;
    }
}