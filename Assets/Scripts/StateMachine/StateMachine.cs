using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 patrolPos;
    private GameObject target;
    private State state;
    private SMVision fov;

    private enum State
    {
        patrol,
        chase
    }


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        fov = GetComponent<SMVision>();
    }

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        state = State.patrol;
    }

    private void Update()
    {
        switch (state)
        {
            case State.patrol:
                Patrol();
                break;
            case State.chase:
                Chase();
                break;
        }
    }
    private void Patrol()
    {
        patrolPos = target.transform.position;
        agent.SetDestination(patrolPos);
        agent.velocity.Set(0, 0, 3.5f);

        FindTarget();
    }

    private void Chase()
    {
        agent.SetDestination(target.transform.position);
        agent.velocity.Set(0, 0, 7);
        if (!fov.canSeePlayer || Vector3.Distance(transform.position, target.transform.position) < 1)
            state = State.patrol;
    }

    private void FindTarget()
    {
        if (target == null)
        {
            state = State.patrol;
            return;
        }

        if (fov.canSeePlayer)
        {
            state = State.chase;
        }
    }

    public bool IsChasing()
    {
        return state.Equals(State.chase);
    }
}
