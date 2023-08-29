using UnityEngine;
using UnityEngine.AI;

public class PlayerMover: MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private MouseInput input;

    private void Start()
    {
        input.OnEnvironmentClick += MoveToPoint;
    }
    public void MoveToPoint(Vector3 point)
    {
            agent.destination = point;
    }
}

