using System;
using UnityEngine;

public enum PickupType
{
    Key,
    Exit
}

public class PickupController : MonoBehaviour
{
    public PickupType myPickupType;

    private void OnEnable()
    {
        PickupEvents.current.keyPickedUp += OnPickKeyUp;
    }

    private void OnDisable()
    {
        PickupEvents.current.keyPickedUp -= OnPickKeyUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (myPickupType == PickupType.Key)
        {
            //this calls the method in the PickupEvents class
            //so when this event is invoked, not only does OnPickKeyUp() get called in this instance (of this class)
            //it also gets called in every other subscriber too
            PickupEvents.current.InvokeKeyPickedUp();
        }
        else
        {
            PickupEvents.current.InvokeExitPickedUp();
        }
    }

    private void OnPickKeyUp()
    {
        if(myPickupType == PickupType.Key)
            //this gets called by PickupEvents, not by the OnTriggerEnter event
            Destroy(gameObject);
    }
}
