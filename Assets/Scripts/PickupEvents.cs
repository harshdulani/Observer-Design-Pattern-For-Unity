using System;
using UnityEngine;

public class PickupEvents : MonoBehaviour
{
    public static PickupEvents current;

    public Action keyPickedUp, exitPickedUp;
    
    private void Awake()
    {
        if (current == null)
            current = this;
        else
            Destroy(this);
    }//make this a singleton

    public void InvokeKeyPickedUp()
    {
        keyPickedUp?.Invoke();
    }

    public void InvokeExitPickedUp()
    {
        exitPickedUp?.Invoke();
    }
}
