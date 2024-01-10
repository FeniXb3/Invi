using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererDisablerComponent : MonoBehaviour
{
    public Renderer rendererToDisable;
    public float reenableDelay = 5.0f;

    void Start()
    {
        if (rendererToDisable == null)
        {
            rendererToDisable = GetComponent<Renderer>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger enter");
        if (other.CompareTag("Player"))
        {   
            rendererToDisable.enabled = false;
            StartCoroutine(ReenableRenderer());
        }
    }

    IEnumerator ReenableRenderer()
    {
        yield return new WaitForSeconds(reenableDelay);
        rendererToDisable.enabled = true;
    }

    // void OnTriggerExit(Collider other)
    // {
    //     Debug.Log("trigger exit");
    //     if (other.CompareTag("Player"))
    //     {
    //         rendererToDisable.enabled = true;
    //     }
    // }
}
