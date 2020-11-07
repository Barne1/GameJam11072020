using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = PlayerManager.Instance.player.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        agent.SetDestination(player.position);

        if (distance < agent.stoppingDistance)
        {
            Debug.Log("lmao attack");
        }
    }
}