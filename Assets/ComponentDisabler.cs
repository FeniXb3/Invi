using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentDisabler : MonoBehaviour
{
    public BoolVariable variable;
    public Renderer component;

    // Start is called before the first frame update
    void Start()
    {
        component.enabled = variable.value;
    }

    // Update is called once per frame
    void Update()
    {
        component.enabled = variable.value;
    }
}
