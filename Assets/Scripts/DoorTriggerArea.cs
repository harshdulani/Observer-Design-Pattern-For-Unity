using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerArea : MonoBehaviour
{
    private DoorController _doorController;

    private void Start()
    {
        _doorController = transform.parent.GetChild(2).GetComponent<DoorController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            DoorEvents.current.InvokeDoorTriggerEnter(_doorController.id, _doorController.isLocked);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
            DoorEvents.current.InvokeDoorTriggerExit(_doorController.id, _doorController.isLocked);
    }
}
