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
        }
        else
        {
            agent.isStopped = true;
        }

    }
}
