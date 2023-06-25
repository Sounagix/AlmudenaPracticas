using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBase : MonoBehaviour
{
    [SerializeField]
    protected Vector3 direccion;

    [SerializeField]
    protected float vel;

    [SerializeField]
    protected int points;

    protected SpawnCalaveras spawnCalaveras;

    public void Init(SpawnCalaveras _spawnCalaveras)
    {
        spawnCalaveras = _spawnCalaveras;
    }


    private void FixedUpdate()
    {
        Movement();
    }

    public virtual void AddPoints()
    {
        GameManager.instance.AddPoints(points);
    }

    protected virtual void Movement()
    {
        transform.Translate(direccion * vel * Time.deltaTime);
    }

    private void OnDestroy()
    {
        spawnCalaveras.OnCalaveraDestroy(gameObject);
    }
}