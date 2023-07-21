using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private MouseInput input;

    private void Start()
    {
        input.OnEnvironmentClick += Input_OnEnvironmentClick;
    }

    private void Input_OnEnvironmentClick(Vector3 point)
    {
        agent.destination = point;
    }
}
