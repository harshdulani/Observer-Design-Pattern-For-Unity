using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;
    
    public Action doorTriggerEnter, doorTriggerExit;
    
    private void Awake()
    {
        if(current == null)
            current = this;
        else
            Destroy(current);
    }//make this a singleton

    public void InvokeDoorTriggerEnter()
    {
        //? means only invoke if not null
        doorTriggerEnter?.Invoke();
    }
    
    public void InvokeDoorTriggerExit()
    {
        //? means only invoke if not null
        doorTriggerExit?.Invoke();
    }
}
