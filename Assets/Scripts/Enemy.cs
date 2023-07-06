using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    [SerializeField] Transform target;
    public float hearRadius;
    public float hearRadiusRun;
    public float hearRadiusWalk;
    public Transform centerPoint;
    public float range;
    private float hearDistance;

    private void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();     
    }
    private void Update()
    {  

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            Vector3 point;
            if(RandomPoint(centerPoint.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                navMeshAgent.SetDestination(point);
            }
        }


        //Find a way to simplfy this and also, figure out how to insert a code that will play a chase music without it reapeating everytime the enemy keeps finding the player
        //You can use a boolean to detect whether or not the player is heard and will only play the music once and then goes back off once the distance from the player is far enough
        hearDistance = Vector3.Distance(transform.position, target.transform.position);
        if (target.GetComponent<FirstPersonController>().CurrentInput.x > 0.1f && hearDistance < hearRadiusWalk || target.GetComponent<FirstPersonController>().CurrentInput.x < -0.1f && hearDistance < hearRadiusWalk)
        {
            //the sequence for the if statement could be turned into a coroutine if you want, or a function by itself like private void playerHeard()
            navMeshAgent.SetDestination(target.position);
            Debug.Log("I CAN HEAR YOU WALKING");      
        }
        else if (target.GetComponent<FirstPersonController>().CurrentInput.x > 3.5f && hearDistance < hearRadiusRun || target.GetComponent<FirstPersonController>().CurrentInput.x < -3.5f && hearDistance < hearRadiusWalk)
        {
            navMeshAgent.SetDestination(target.position);
            Debug.Log("I CAN HEAR YOU RUNNING");
        }
        else if (target.GetComponent<FirstPersonController>().CurrentInput.y > 0.1f && hearDistance < hearRadiusWalk || target.GetComponent<FirstPersonController>().CurrentInput.y < -0.1f && hearDistance < hearRadiusWalk)
        {
            navMeshAgent.SetDestination(target.position);
            Debug.Log("I CAN HEAR YOU WALKING");
        }
        else if (target.GetComponent<FirstPersonController>().CurrentInput.y > 3.5f && hearDistance < hearRadiusRun || target.GetComponent<FirstPersonController>().CurrentInput.y < -3.5f && hearDistance < hearRadiusRun)
        {
            navMeshAgent.SetDestination(target.position);
            Debug.Log("I CAN HEAR YOU RUNNING");
        }
        else if (hearDistance < hearRadius)
        {
            navMeshAgent.SetDestination(target.position);
            Debug.Log("I CAN HEAR BREATHING");
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hearDistance < hearRadius)
        {
            Debug.Log("I CAUGHT YOU");
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    /*
     * Would be great to use this instead of repeating the same code for the if statements
     * Figure out how to make the enemy speed up using navmesh.speed = 5 or 6 whenever the enemy detects the player and then go back to 3 when they are no longer detected
     * 
    private void playerHeard()
    {
        navMeshAgent.SetDestination(target.position);
    }
    */
}
