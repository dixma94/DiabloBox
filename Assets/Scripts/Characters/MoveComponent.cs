using UnityEngine;
using UnityEngine.AI;

public class MoveComponent: MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    public void MoveToPoint(Vector3 point)
    {
            agent.destination = point;
    }
}

