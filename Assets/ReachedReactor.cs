using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedReactor : MonoBehaviour
{
    public Transform targetTransform;
    public CustomEvent enemyTargetReached;

    void OnEnable()
    {
        enemyTargetReached.onCustomEventRaised += React;
    }

    void OnDisable()
    {
        enemyTargetReached.onCustomEventRaised -= React;
    }

    public void React()
    {
        Debug.Log("Player reached");
        transform.position = targetTransform.position;
    }
}
