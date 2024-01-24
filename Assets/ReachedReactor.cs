using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReachedReactor : MonoBehaviour
{
    public Transform targetTransform;

    public void React()
    {
        transform.position = targetTransform.position;
    }
}
