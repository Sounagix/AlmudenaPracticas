using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Spawner spawner;

    private void Start()
    {
        spawner = GameObject.Find("PoolEnemigos").GetComponent<Spawner>();
    }


    private void OnDestroy()
    {
        spawner.OnEnemyDie();
    }
}
