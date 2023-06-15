using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private float bulletSpeed;

    [SerializeField]
    private Transform gunExit;

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bulletPrefab, transform);
        currentBullet.transform.position = gunExit.transform.position;
        var rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
