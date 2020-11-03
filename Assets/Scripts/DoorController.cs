using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;
    
    private float restingHeight = 1.5f;
    private float openedHeight = 4f;
    
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

    private void OnDoorTriggerEnter(int doorID)
    {
        if (doorID == id)
        {
            StopCoroutine(_closeDoorCo);
            StartCoroutine(_openDoorCo);
        }
    }

    private void OnDoorTriggerExit(int doorID)
    {
        if (doorID == id)
        {
            StopCoroutine(_openDoorCo);
            StartCoroutine(_closeDoorCo);
        }
    }

    private IEnumerator OpenDoor()
    {
        while(transform.position.y <= openedHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, _openedPos, lerpSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    private IEnumerator CloseDoor()
    {
        while(transform.position.y >= restingHeight)
        {
            transform.position = Vector3.MoveTowards(transform.position, _restingPos, lerpSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
