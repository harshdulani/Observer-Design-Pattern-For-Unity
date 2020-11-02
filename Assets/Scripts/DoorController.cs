using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float restingHeight = 1.5f;
    public float openedHeight = 4f;
    
    public float lerpSpeed = 0.05f;

    private Vector3 _restingPos, _openedPos;
    private IEnumerator _openDoorCo, _closeDoorCo;

    private void Start()
    {
        var position = transform.position;
        _restingPos = new Vector3(position.x, restingHeight, position.z);
        _openedPos = new Vector3(position.x, openedHeight, position.z);

        _openDoorCo = OpenDoor();
        _closeDoorCo = CloseDoor();
    }
    
    private void OnEnable()
    {
        DoorEvents.current.doorTriggerEnter += OnDoorTriggerEnter;
        DoorEvents.current.doorTriggerExit += OnDoorTriggerExit;
    }

    private void OnDisable()
    {
        DoorEvents.current.doorTriggerEnter -= OnDoorTriggerEnter;
        DoorEvents.current.doorTriggerExit -= OnDoorTriggerExit;
    }

    private void OnDoorTriggerEnter()
    {
        StopCoroutine(_closeDoorCo);
        StartCoroutine(_openDoorCo);
    }

    private void OnDoorTriggerExit()
    {
        StopCoroutine(_openDoorCo);
        StartCoroutine(_closeDoorCo);
    }

    private IEnumerator OpenDoor()
    {
        print("Door entry called");
        while(transform.position.y <= openedHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, _openedPos, lerpSpeed);
            print("opening");
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    private IEnumerator CloseDoor()
    {
        print("Door exit called");
        while(transform.position.y >= restingHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, _restingPos, lerpSpeed);
            print("closing");
            yield return new WaitForSeconds(0.05f);
        }
    }
}
