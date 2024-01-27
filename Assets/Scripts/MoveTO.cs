using UnityEngine;
using UnityEngine.AI;
    
public class MoveTo : MonoBehaviour {
    void Start () {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        // agent.destination = Target.instance.transform.position;
    }
}
