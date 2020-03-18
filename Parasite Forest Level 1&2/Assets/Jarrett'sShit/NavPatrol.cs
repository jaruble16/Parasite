// Patrol.cs
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;


public class NavPatrol : MonoBehaviour
{

    public List<Transform> destinationPoints = new List<Transform>();
    public Transform AggroTarget;
    private int index = 0;
    private int DistanceFromTarget;
    public NavMeshAgent agent;
    public MeshCollider AggroVision;
    public SphereCollider DeAggroRange;
    public Transform goal;
    public Transform goal2;
    public Transform goal3;
    public Transform goal4;
    public Transform goal5;
    public Transform goal6;
    public Transform goal7;

    public bool hasAggro = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        destinationPoints.Add(goal);
        destinationPoints.Add(goal2);
        destinationPoints.Add(goal3);
        destinationPoints.Add(goal4);
        destinationPoints.Add(goal5);
        destinationPoints.Add(goal6);
        destinationPoints.Add(goal7);

        

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();

        
    }


    public void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (destinationPoints.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = destinationPoints[index].position;
        index++;
        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        if (index >= destinationPoints.Count)
        {
            index = 1;
        }
        // index = index % destinationPoints.Count;
        // Debug.Log("index =" + index);
    }


    void Update()
    {



        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f && hasAggro == false)
        {
            GotoNextPoint();
        }
        else if (!agent.pathPending && hasAggro == true && gameObject.tag == "Prey")
        {
            agent.ResetPath();   
            Flee();
        }
        else if (!agent.pathPending && hasAggro == true && gameObject.tag == "Predator")
        {
            agent.ResetPath();
            Chase();
        }
    }



    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        hasAggro = true;
    //        agent.speed = agent.speed;// * 2;
    //        Debug.Log("Player Trigger");
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        hasAggro = false;
    //        agent.ResetPath();
    //        GotoNextPoint();
    //    }
    //}


    public void Flee()
    {
        agent.ResetPath();
        AggroTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent.nextPosition = Vector3.MoveTowards(transform.position, AggroTarget.position, -agent.speed * Time.deltaTime);
        
    }

    public void Chase()
    {
        agent.ResetPath();
        AggroTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        agent.nextPosition = Vector3.MoveTowards(transform.position, AggroTarget.position, agent.speed * Time.deltaTime);
    }
}
