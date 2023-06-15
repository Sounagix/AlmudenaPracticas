using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoter : MonoBehaviour
{
    [SerializeField]
    private KeyCode adelante;

    [SerializeField]
    private KeyCode atras;

    [SerializeField]
    private KeyCode izquierda;

    [SerializeField]
    private KeyCode derecha;

    [SerializeField]
    private float moveSpeed;

    private Gun gun;

    private GranadeGun granadeGun;

    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gun = GetComponentInChildren<Gun>();
        granadeGun = GetComponentInChildren<GranadeGun>();
    }


    private void Update()
    {
        if (Input.GetKey(adelante))
        {
            Move(Vector3.forward);
        }
        else if (Input.GetKey(atras))
        {
            Move(-Vector3.forward);
        }
        else if (Input.GetKey(izquierda))
        {
            Move(Vector3.left);
        }
        else if (Input.GetKey(derecha))
        {
            Move(Vector3.right);
        }

        if (Input.GetMouseButtonDown(0))
        {
            gun.ShootRayCast();
        }
        if (Input.GetMouseButtonDown(1))
        {
            granadeGun.Shoot();
        }
    }

    private void Move(Vector3 dir)
    {
        rb.AddForce(dir * moveSpeed , ForceMode.Acceleration);
    }

}
