using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointNPC : MonoBehaviour
{
    public WayPointNPC[] wayPointNPCs;
    public NPCType npc_type;

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 1);
    }
}
