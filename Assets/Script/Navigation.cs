using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{
    public GameObject charactor;
    private NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void NavToPosition(Vector3 position)
    {
        Debug.Log(position);
        _agent.destination = position;
    }

    // Update is called once per frame
    public void NavToChar()
    {
        _agent.destination = charactor.transform.position;
    }
    public void ResetPath()
    {
        _agent.ResetPath();
    }
}
