using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CustomEvent : ScriptableObject
{
    public Action onCustomEventRaised;
    public void RaiseEvent()
    {
        onCustomEventRaised?.Invoke();
    }
}
