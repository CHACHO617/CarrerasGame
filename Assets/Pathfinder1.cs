using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ContinuousPathfinding : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    public GameManager GameManager;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Check if the target is not null before accessing its position
        if (target != null)
        {
            // Set the destination to the target's position
            agent.destination = target.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (target != null)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(other.gameObject);
                GameManager.Die();
            }
        }
    }
}