using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GhoulController : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    private Animator anim;
    private List<Transform> waypoints;
    private int currWaypoint;
    private Vector3 lastposition;

    private float walk_speed = 6f;
    private float run_speed = 20f;

    private bool found_marked;

    private float min_radius = 25f;
    private float walk_radius = 40f;
    private float run_radius = 60f;

    public AudioSource scream;
    public AudioSource patrol;
    private bool sound;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
        waypoints = new List<Transform>();

        GameObject navi = GameObject.Find("Navi Positions");

        for (int i = 0; i < navi.transform.childCount; i++)
        {
            waypoints.Add(navi.transform.GetChild(i));
        }

        currWaypoint = UnityEngine.Random.Range(0, waypoints.Count);
        SetNextWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance <= 5 && !agent.pathPending)
        {
            if (anim.GetBool("Found"))
            {
                GameObject.Find("Player").GetComponent<PlayerController>().lose = true;
            }
            SetNextWaypoint();
        }

        // Found Player?
        if (GetComponent<FieldOfView>().canSeePlayer)
        {
            if (sound == false){
                patrol.loop = false;
                scream.Play();
                scream.loop = true;
                sound = true;
            }            
            anim.SetBool("Found", true);
        }
        else
        {
            if (sound == true){
                scream.loop = false;
                patrol.Play();
                patrol.loop = true;
                sound = false;
            }
            anim.SetBool("Found", false);
        }


        // Boolean
        if (anim.GetBool("Found"))
        {
            agent.speed = run_speed;
            lastposition = GameObject.Find("Player").transform.position;
            agent.SetDestination(lastposition);
            found_marked = true;
        }
        else
        {
            agent.speed = walk_speed;
            
            if (found_marked && Vector3.Distance(transform.position, lastposition) > 5)
            {
                agent.SetDestination(lastposition);
            }
            else
            {
                found_marked = false;
                agent.SetDestination(waypoints[currWaypoint].position);
            }
        }

        // Close Proximity
        if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < min_radius)
        {
            agent.SetDestination(GameObject.Find("Player").transform.position);
        }

        // Walking Proximity
        if (GameObject.Find("Player").GetComponentInChildren<Animator>().GetFloat("Speed") > 0.33)
        {
            if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < walk_radius)
            {
                agent.SetDestination(GameObject.Find("Player").transform.position);
            }
        }

        // Running Proximity
        if (GameObject.Find("Player").GetComponentInChildren<Animator>().GetBool("Run"))
        {
            if (Vector3.Distance(transform.position, GameObject.Find("Player").transform.position) < run_radius)
            {
                agent.SetDestination(GameObject.Find("Player").transform.position);
            }
        }
    }

    private void SetNextWaypoint()
    {
        // Empty Waypoint Array
        if (waypoints == null || waypoints.Count == 0)
        {
            throw new ArgumentOutOfRangeException("Null array or no elements.");
        }

        int next;

        do
        {
            next = UnityEngine.Random.Range(0, waypoints.Count);
        } while (next == currWaypoint);

        currWaypoint = next;
        Debug.Log(waypoints[currWaypoint].position);
        agent.SetDestination(waypoints[currWaypoint].position);
    }
}
