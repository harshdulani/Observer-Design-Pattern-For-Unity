using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float restingHeight = 1.5f;
    public float openedHeight = 4f;
    
    public float lerpSpeed = 0.05f;

    private Vector3 _restingPos, _openedPos;

    private void Start()
    {
        var localPosition = transform.localPosition;
        _restingPos = new Vector3(localPosition.x, restingHeight, localPosition.z);
        _openedPos = new Vector3(localPosition.x, openedHeight, localPosition.z);
    }

    public void OpenDoor()
    {
        StopAllCoroutines();
        StartCoroutine(DoOpenDoor());
    }

    public void CloseDoor()
    {
        StopAllCoroutines();
        StartCoroutine(DoCloseDoor());
    }

    private IEnumerator DoOpenDoor()
    {
        for (float f = transform.localPosition.y; f <= openedHeight; f += lerpSpeed)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _openedPos, lerpSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    private IEnumerator DoCloseDoor()
    {
        for (float f = transform.localPosition.y; f >= restingHeight; f += lerpSpeed)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _openedPos, lerpSpeed);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
