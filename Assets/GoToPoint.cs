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
    public BoolVariable playerVisibility;

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
            if (!playerVisibility.value)
            {
                chase = false;
            }

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

    void FixedUpdate()
    {
        if (!playerVisibility.value)
        {
            return;
        }

        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        Transform playerTransform = null;
    
        RaycastHit[] result = Physics.SphereCastAll(transform.position, 2, fwd);
        foreach (RaycastHit item in result)
        {
            if (item.transform.gameObject.CompareTag("Player"))
            {
                playerTransform = item.transform;
            }
        }

        if (playerTransform == null)
        {
            return;
        }


        Vector3 direction = playerTransform.position - transform.position;
        direction.y = playerTransform.position.y;

        Debug.Log($"Vector: {direction.magnitude} | Normalized: {direction.normalized.magnitude}");
        
        Debug.DrawRay(transform.position, direction, Color.red);
        if (Physics.Raycast(transform.position, direction, out RaycastHit hitInfo, 100) && hitInfo.transform.gameObject.CompareTag("Player"))
        {
            targetTransform = hitInfo.transform;
            shouldMove = true;
            chase = true;
            Debug.Log("raycast");
            Debug.DrawRay(transform.position, direction.normalized * hitInfo.distance, Color.red);
        }
        else
        {
            targetTransform = null;
            shouldMove = false;
            chase = false;
            Debug.Log("raycast didn't hit player");
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