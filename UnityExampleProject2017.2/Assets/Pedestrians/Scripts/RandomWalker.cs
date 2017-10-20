﻿using UnityEngine;
using System.Collections;

public class RandomWalker : MonoBehaviour {
    public float timeNewTarget = 2f; // time before changing destination
    Animator anim;
    float timer;

    // Reference to the NavMeshAgent component.
    UnityEngine.AI.NavMeshAgent agent;

    void Awake() {
        //references
        anim = GetComponent<Animator>();
        agent = GetComponentInParent<UnityEngine.AI.NavMeshAgent>();
        ChangeTarget();
    }
    // Update is called once per frame
    void Update() {
        // tell animator if moving
        anim.SetBool("isWalking", agent.hasPath);

        // walk timer
        if (timer > timeNewTarget) {
            ChangeTarget();
            //reset timer for when to call changeTarget
            timeNewTarget = Random.Range(3f, 15f);
            timer = 0f;
        }

        //Add the time since the last update to timer
        timer += Time.deltaTime;
    }

    void ChangeTarget(float maxDistance = 10f) {
        Vector3 randomDirection = Random.insideUnitSphere * maxDistance;

        //set agent destination
        randomDirection += transform.position;
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(randomDirection, out hit, maxDistance, 1);
        agent.SetDestination(hit.position);
    }

    public void Scatter(Vector3 point) {
        //pass scatter distance 2f as arguement
        ChangeTarget(point,20f);
    }


    //Overflow Not working as intended
    void ChangeTarget(Vector3 impactPoint, float maxDistance = 10f)
    {
        Vector3 direction = (transform.position - impactPoint) * maxDistance;

        //set agent destination
        UnityEngine.AI.NavMeshHit hit;
        UnityEngine.AI.NavMesh.SamplePosition(direction, out hit, maxDistance, 1);
        agent.SetDestination(hit.position);
        Debug.Log("Scatter to " + hit.position.ToString());
    }


}
