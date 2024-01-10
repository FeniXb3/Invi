using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformReseter : MonoBehaviour
{
    public Vector3 startingPositon;
    public Vector3 startingRotationAngles;

    // Start is called before the first frame update
    void Start()
    {
        startingPositon = transform.position;
        startingRotationAngles = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log($"reset {name}");
            transform.position = startingPositon;
            transform.rotation = Quaternion.Euler(startingRotationAngles);
        }
    }
}
