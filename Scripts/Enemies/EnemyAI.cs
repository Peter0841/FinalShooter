using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform Player;
    NavMeshAgent agent;
    
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3f;
        agent.stoppingDistance = 2.5f;

        // Find our player object
        Player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        // Make our enemy go to the player
        agent.SetDestination(Player.position);
    }
}
