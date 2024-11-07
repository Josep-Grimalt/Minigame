using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{

    [SerializeField] private Transform point;
    private NavMeshAgent agent;
    private Vector3 patrolPos;
    private GameObject target;
    private State state;
    private float timer = 0;
    private SMVision fov;
    private enum State
    {
        wait,
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
        state = State.wait;
    }

    private void Update()
    {
        switch (state)
        {
            case State.wait:
                Wait();
                break;
            case State.patrol:
                Patrol();
                break;
            case State.chase:
                Chase();
                break;
        }
    }

    private void Wait()
    {
        Debug.Log("Waiting...");
        agent.isStopped = true;

        timer += Time.deltaTime;

        if (timer >= 1)
        {
            timer = 0;
            state = State.patrol;
        }
    }

    private void Patrol()
    {
        Debug.Log("Patrolling...");
        agent.isStopped = false;

        patrolPos = point.position;
        agent.SetDestination(patrolPos);
        agent.velocity.Set(0, 0, 3.5f);

        FindTarget();
    }

    private void Chase()
    {
        Debug.Log("Chasing...");

        agent.SetDestination(target.transform.position);
        agent.velocity.Set(0, 0, 7);
        if (!fov.canSeePlayer || Vector3.Distance(transform.position, target.transform.position) < 1)
            state = State.wait;
    }

    private void FindTarget()
    {
        if (target == null)
            return;

        if (fov.canSeePlayer)
        {
            state = State.chase;
        }
    }
}
