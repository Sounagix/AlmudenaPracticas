using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGun : MonoBehaviour
{
    [SerializeField]
    private float cadencia;

    private float tiempoDisparo = 0.0f;

    [SerializeField]
    private Transform salidaBala;

    [SerializeField]
    private float distance;


    private void Update()
    {
        if (Input.anyKey)
        {
            if (Input.GetMouseButtonDown(0) && PuedoDisparar())
            {
                Dispara();
            }
        }
    }

    private bool PuedoDisparar()
    {
        return Time.fixedUnscaledTime - tiempoDisparo > cadencia;
    }

    private  void Dispara()
    {
        tiempoDisparo = Time.fixedUnscaledTime;
        Vector3 initPos = salidaBala.position;
        Vector3 direccion = transform.forward;
        int layer = (1 << 8);
        RaycastHit[] raycastHit = Physics.RaycastAll(initPos, direccion, distance, layer, QueryTriggerInteraction.Ignore);
        if (raycastHit != null && raycastHit.Length > 0)
        {
            int size = raycastHit.Length;
            Debug.DrawLine(initPos, raycastHit[size - 1].point, Color.red, cadencia);
            for (int i = 0; i < size; i++)
            {
                TargetBase target = raycastHit[i].collider.gameObject.GetComponent<TargetBase>();
                if (target != null)
                {
                    target.AddPoints();
                }
                Destroy(raycastHit[i].collider.gameObject);
            }
        }
        else
        {
            Debug.DrawRay(initPos, initPos + (direccion * distance), Color.blue, cadencia);
        }
    }
}
