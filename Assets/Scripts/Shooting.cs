using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] private float shootingSpeed = 2f;

    public float bulletForce = 20f;
    public bool allowFire { get; set; }

    private void Start()
    {
        allowFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!allowFire)
            return;
        StartCoroutine(Shoot());
        
    }

    IEnumerator Shoot()
    {
        allowFire = false;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(this.transform.forward * bulletForce, ForceMode.Impulse);
        Destroy(bullet, 5f);
        yield return new WaitForSeconds(shootingSpeed);
        allowFire = true;
    }
}
