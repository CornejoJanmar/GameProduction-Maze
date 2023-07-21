using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
using UnityEngine.SceneManagement;

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
    private bool canHearPlayer;

    private void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();     
        canHearPlayer = true;
    }
    
    private void Update()
    {  
        hearDistance = Vector3.Distance(transform.position, target.transform.position);

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

        if(canHearPlayer){
            if (target.GetComponent<FirstPersonController>().CurrentInput.x > 0.1f && hearDistance < hearRadiusWalk || target.GetComponent<FirstPersonController>().CurrentInput.x < -0.1f && hearDistance < hearRadiusWalk)
            {
                playerHeard();
                Debug.Log("I CAN HEAR YOU WALKING");      
            }
            else if (target.GetComponent<FirstPersonController>().CurrentInput.x > 3.5f && hearDistance < hearRadiusRun || target.GetComponent<FirstPersonController>().CurrentInput.x < -3.5f && hearDistance < hearRadiusRun)
            {
                playerHeard();
                Debug.Log("I CAN HEAR YOU RUNNING");
            }
            else if (target.GetComponent<FirstPersonController>().CurrentInput.y > 0.1f && hearDistance < hearRadiusWalk || target.GetComponent<FirstPersonController>().CurrentInput.y < -0.1f && hearDistance < hearRadiusWalk)
            {
                playerHeard();
                Debug.Log("I CAN HEAR YOU WALKING");
            }
            else if (target.GetComponent<FirstPersonController>().CurrentInput.y > 3.5f && hearDistance < hearRadiusRun || target.GetComponent<FirstPersonController>().CurrentInput.y < -3.5f && hearDistance < hearRadiusRun)
            {
                playerHeard();
                Debug.Log("I CAN HEAR YOU RUNNING");
            }
            else if (hearDistance < hearRadius)
            {
                playerHeard();
                Debug.Log("I CAN HEAR BREATHING");
            }
        }      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && hearDistance < hearRadius)
        {
            Debug.Log("I CAUGHT YOU");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

    private void playerHeard()
    {
        //change of plans, enemy will hear the player once and the enemy will jsut charge at the player anywhere they are once they've been heard. 
        //We need to make it so that the enemy makes louder sounds to signal the position of the enemy to the player.

        navMeshAgent.SetDestination(target.position);
        //canHearPlayer = false;
    }

}
