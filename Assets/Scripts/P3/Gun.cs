using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Transform gunExit;

    /// <summary>
    /// Shoot con instancia
    /// </summary>
    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bulletPrefab, transform);
        currentBullet.transform.position = gunExit.transform.position;
        var rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    public void ShootRayCast()
    {
        // posición inicial del rayo
        Vector3 initPosition = transform.position;
        Vector3 direction = transform.forward; //(0,0,1.0)
        RaycastHit hit;
        float distance = 10.0f;
        int layer = (1 << 8);

        Debug.DrawRay(initPosition, transform.position + (direction * distance), Color.red, 1.0f);

        //if (Physics.Raycast(initPosition, direction, out hit, distance, layer, QueryTriggerInteraction.Ignore)) 
        //{
        //    Destroy(hit.collider.gameObject);
        //}

        RaycastHit[] raycastHits;

        raycastHits = Physics.RaycastAll(initPosition, direction, distance, layer, QueryTriggerInteraction.Ignore);

        //int cantidad = raycastHits.Length;
        //for (int i = 0; i < cantidad; i++)
        //{
        //    Destroy(raycastHits[i].collider.gameObject);
        //    
        //}

        foreach (RaycastHit rch in raycastHits)
        {
            Destroy(rch.collider.gameObject);
        }
    }

    public void ShootGranade()
    {

    }
}
