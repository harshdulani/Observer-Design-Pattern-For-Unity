using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    private GameObject _door;

    private void Start()
    {
        _door = transform.parent.GetChild(2).gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            DoorEvents.current.InvokeDoorTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            DoorEvents.current.InvokeDoorTriggerExit();
    }
}
