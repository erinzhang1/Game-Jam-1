using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateState : MonoBehaviour
{
    // we have two kinds of state: Wander, Chase
    public GameObject enemy;
    private string _currentState;
    public bool playerVisible;
    public const float VisibleDistance = 5f;

    public GameObject charactor;
    private NavMeshAgent _agent;

    // Start is called before the first frame update
    void Start()
    {
        _currentState = "Wander";
        playerVisible = true;

        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (_currentState)
        {
            case "Wander":
                UpdateWander();
                break;
            case "Chase":
                UpdateChase();
                break;
        }
        // then switch between walk or stand base on velocity
    }

    private void UpdateWander()
    {
        if (playerVisible)
        {
            _currentState = "Chase";
            _agent.ResetPath();
            return;
        }
        // set a random position as target around 4f, 4f
        Vector3 tempPos = enemy.transform.position + new Vector3(Random.Range(-20f, 20f), 0, Random.Range(-20f, 20f));
        _agent.destination = tempPos;
    }

    private void UpdateChase()
    {
        if (!playerVisible)
        {
            _currentState = "Wander";
            _agent.ResetPath();
            return;
        }
        _agent.destination = charactor.transform.position;
    }
}
