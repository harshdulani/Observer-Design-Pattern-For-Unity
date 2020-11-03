using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DoorEvents : MonoBehaviour
{
    public static DoorEvents current;
    
    public Action<int> doorTriggerEnter, doorTriggerExit;
    
    private void Awake()
    {
        if(current == null)
            current = this;
        else
            Destroy(this);
    }//make this a singleton

    public void InvokeDoorTriggerEnter(int id)
    {
        //? means only invoke if not null
        doorTriggerEnter?.Invoke(id);
    }
    
    public void InvokeDoorTriggerExit(int id)
    {
        //? means only invoke if not null
        doorTriggerExit?.Invoke(id);
    }
}
