using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoolVariableSetter : MonoBehaviour
{
    public float reenableDelay = 5.0f;
    // public BoolVariable viariable;
    public UnityEvent playerEnteredEvent;
    public UnityEvent delayPassedEvent;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            // viariable.value = false;
            playerEnteredEvent.Invoke();
            StartCoroutine(ReenableRenderer());
        }
    }

    IEnumerator ReenableRenderer()
    {
        yield return new WaitForSeconds(reenableDelay);
        // viariable.value = true;
        delayPassedEvent.Invoke();
    }
}
