using System;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;
    
    public Action<int, bool> doorTriggerEnter, doorTriggerExit;
    
    private void Awake()
    {
        if(current == null)
            current = this;
        else
            Destroy(this);
    }//make this a singleton

    public void InvokeDoorTriggerEnter(int id, bool isLocked = false)
    {
        //? means only invoke if not null
        doorTriggerEnter?.Invoke(id, isLocked);
    }
    
    public void InvokeDoorTriggerExit(int id, bool isLocked = false)
    {
        //? means only invoke if not null
        doorTriggerExit?.Invoke(id, isLocked);
    }
}
