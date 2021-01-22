using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _transform;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            var movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _agent.destination = _transform.position + movementVector;
        }
    }
}
