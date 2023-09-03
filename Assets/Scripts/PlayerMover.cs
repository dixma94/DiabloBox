using UnityEngine;
using UnityEngine.AI;

public class PlayerMover: MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;


    private void Start()
    {
      
    }
    public void MoveToPoint(Vector3 point)
    {
            agent.destination = point;
    }
}

