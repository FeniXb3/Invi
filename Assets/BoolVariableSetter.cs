using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolVariableSetter : MonoBehaviour
{
    public float reenableDelay = 5.0f;
    public BoolVariable viariable;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {
            viariable.value = false;
            StartCoroutine(ReenableRenderer());
        }
    }

    IEnumerator ReenableRenderer()
    {
        yield return new WaitForSeconds(reenableDelay);
        viariable.value = true;
    }
}
