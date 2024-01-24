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
            TriggerPlayerChasing();
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
            Debug.Log($"Distance: {distance}");
            if (distance <= stoppingDistance)
            {
                agent.isStopped = true;
                shouldMove = false;
                chase = false;
                targetTransform.gameObject.SendMessage("React");

                targetTransform = null;
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

    void TriggerPlayerChasing()
    {
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            targetTransform = player.transform;
            shouldMove = !shouldMove;
            chase = shouldMove;
        }
    }
}
