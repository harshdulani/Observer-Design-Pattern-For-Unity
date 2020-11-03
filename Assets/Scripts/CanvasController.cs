using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Text objective, status;

    private void OnEnable()
    {
        DoorEvents.current.doorTriggerEnter += OnDoorTriggerEnter;
        DoorEvents.current.doorTriggerExit += OnDoorTriggerExit;

        PickupEvents.current.keyPickedUp += OnKeyPickup;
        PickupEvents.current.exitPickedUp += OnExitPickup;
    }

    private void Start()
    {
        StartCoroutine(TurnOffStatus());
    }

    private void OnDisable()
    {
        DoorEvents.current.doorTriggerEnter -= OnDoorTriggerEnter;
        DoorEvents.current.doorTriggerExit -= OnDoorTriggerExit;

        PickupEvents.current.keyPickedUp -= OnKeyPickup;
        PickupEvents.current.exitPickedUp -= OnExitPickup;
    }

    private void OnDoorTriggerEnter(int id, bool isLocked)
    {
        if (isLocked)
            status.text = "This door is locked. You need to pickup a red cube to unlock this.";
    }

    private void OnDoorTriggerExit(int id, bool isLocked)
    {
        if (isLocked)
            status.text = "";
    }

    private void OnKeyPickup()
    {
        status.text = "The door is now unlocked!";
    }

    private void OnExitPickup()
    {
        status.text = "";
        objective.text = "Game Over!";
    }

    private IEnumerator TurnOffStatus()
    {
        yield return new WaitForSeconds(5f);
        status.text = "";
    }
}
