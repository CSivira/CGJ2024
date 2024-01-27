using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class MoveTo : MonoBehaviour
{
    public Transform target;

    public void setTarget(Transform t)
    {
        target = t;
    }

    void Start () {

        if (target == null)
        {
            target = transform;
        }

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
    }
}
