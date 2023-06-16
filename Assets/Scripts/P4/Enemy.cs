using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ENEMY_STATE
{
    PAUSE, MOVING, FOLLOWING,
}


[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float distanceToStop;

    private GameObject patrullaObj;

    private GameObject player;

    private Spawner spawner;

    private NavMeshAgent agent;

    private int indexPatrulla = 0;

    protected ENEMY_STATE eNEMY_STATE;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    private void Start()
    {
        //player = GameObject.Find("Player");
        patrullaObj = GameObject.Find("Patrullas");
        spawner = GameObject.Find("PoolEnemigos").GetComponent<Spawner>();
        InitPatrulla();
    }

    protected virtual void InitPatrulla()
    {
        eNEMY_STATE = ENEMY_STATE.MOVING;
        int size = patrullaObj.transform.childCount;
        int choice = -1;
        do
        {
            choice = Random.Range(0, size);
        }
        while (choice == indexPatrulla);
        indexPatrulla = choice;
        agent.SetDestination(patrullaObj.transform.GetChild(indexPatrulla).transform.position);
    }

    protected virtual void NextPatrulla()
    {
        float t = 2.0f;
        eNEMY_STATE = ENEMY_STATE.PAUSE;
        StartCoroutine(WaitTime(t));
    }

    private void MoveToPlayer()
    {
        if (NavMesh.CalculatePath(transform.position, player.transform.position, -1, agent.path))
        {
            agent.stoppingDistance = distanceToStop;
            agent.SetDestination(player.transform.position);
        }
        else
        {
            agent.stoppingDistance = distanceToStop;
            agent.SetDestination(Vector3.zero);
        }
    }

    protected IEnumerator WaitTime(float t)
    {
        yield return new WaitForSecondsRealtime(t);
        InitPatrulla();
    }

    private void FixedUpdate()
    {
        switch (eNEMY_STATE)
        {
            case ENEMY_STATE.PAUSE:
                break;
            case ENEMY_STATE.MOVING:
                if (player == null)
                {
                    if (agent.velocity.magnitude <= 0.1f)
                    {
                        NextPatrulla();
                    }
                }
                else
                {
                    eNEMY_STATE = ENEMY_STATE.FOLLOWING;
                }
                break;
            case ENEMY_STATE.FOLLOWING:
                MoveToPlayer();
                break;
        }
    }

    public void SetEnemy(GameObject _player)
    {
        eNEMY_STATE = ENEMY_STATE.FOLLOWING;
        player = _player;
    }

    private void OnDestroy()
    {
        spawner.OnEnemyDie();
    }
}
