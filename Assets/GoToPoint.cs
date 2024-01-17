using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToPoint : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform targetTransform;
    public bool shouldMove;
    public bool chase;
    public float stoppingDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            shouldMove = !shouldMove;
            chase = shouldMove;
        }

        if (targetTransform == null)
        {
            return;
        }

        if (shouldMove)
        {
            if (chase || (!chase && agent.isStopped))
            {
                agent.destination = targetTransform.position;
                agent.isStopped = false;
            }

            float distance = (transform.position - agent.destination).magnitude;
            if (distance <= stoppingDistance)
            {
                agent.isStopped = true;
                shouldMove = false;
                chase = false;
                Debug.Log("Destination reached");
            }
        }
        else
        {
            agent.isStopped = true;
        }

    }

    void GoTo(Transform target)
    {
        Debug.Log(agent.isStopped);
        targetTransform = target;
        shouldMove = true;
        chase = false;
    }
}
