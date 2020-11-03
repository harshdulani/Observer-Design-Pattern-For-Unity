using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    private int _doorID;

    private void Start()
    {
        _doorID = transform.parent.GetChild(2).GetComponent<DoorController>().id;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            DoorEvents.current.InvokeDoorTriggerEnter(_doorID);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            DoorEvents.current.InvokeDoorTriggerExit(_doorID);
    }
}
