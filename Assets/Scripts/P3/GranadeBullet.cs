using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeBullet : MonoBehaviour
{
    [SerializeField]
    private float timeToExplote;

    [SerializeField]
    private float radius;

    private float initTime;

    private float currentTime;

    private bool actived = false;

    private Vector3 drawPos;

    private bool explotionActive = false;


    private void OnCollisionEnter(Collision collision)
    {
        initTime = Time.realtimeSinceStartup;
        actived = true;
    }

    private void FixedUpdate()
    {
        if (actived)
        {
            currentTime = Time.realtimeSinceStartup;
            if (currentTime - initTime > timeToExplote)
            {
                Explote();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (explotionActive)
        {
            Gizmos.DrawSphere(drawPos, radius);
        }
    }

    private void Explote()
    {
        Vector3 initPos = transform.position;
        int layer = (1 << 8);
        RaycastHit[] hits = Physics.SphereCastAll(initPos, radius, transform.up, 10, layer, QueryTriggerInteraction.Ignore);
        explotionActive = true;
        drawPos = initPos;

        foreach (RaycastHit rch in hits)
        {
            Destroy(rch.collider.gameObject);
        }

        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
