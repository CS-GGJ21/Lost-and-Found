﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private bool ghostly;
    [SerializeField]
    private float detectionDistance;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LayerMask detectionMask;
    private int state;
    private NavMeshAgent navMeshAgent;
    private GameObject[] players;
    private Transform target;

    // Set up references
    void Awake()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        state = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case 0:
                FindNewTarget();
                if (target != null)
                {
                    navMeshAgent.SetDestination(target.position);
                    Debug.DrawLine(this.gameObject.transform.position, target.position, Color.magenta, 0.1f);
                }
                break;
        }
    }

    void FindNewTarget()
    {
        target = null;
        float lowest_distance = Mathf.Infinity;
        if (ghostly)
        {
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                if (distance < lowest_distance)
                {
                    target = player.transform;
                    lowest_distance = distance;
                }
            }
        }
        else
        {
            foreach (GameObject player in players)
            {
                float distance = Vector3.Distance(this.transform.position, player.transform.position);
                //Ray ray = Physics.Raycast(this.transform.position, (player.transform.position - this.transform.position).normalized, detectionDistance, detectionMask);
                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, (player.transform.position - this.transform.position).normalized, out hit) 
                    && hit.collider.gameObject == player 
                    && distance < lowest_distance) {
                    target = player.transform;
                    lowest_distance = distance;
                }
            }
        }
    }
}
