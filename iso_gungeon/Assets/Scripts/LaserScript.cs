using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    LineRenderer line;
    public GameObject bullet;
    public float bulletSpeed = 100f;
    public float damage = 10f;
    public float range = 100f;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }

    void Update()
    {
        // if (Input.GetButtonDown("Fire1"))
        // {
            //ShootLaser();
            // StopCoroutine("FireLaser");
            // StartCoroutine("FireLaser");
        // }
    }

    void    Shoot()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody instBulletRb = instBullet.GetComponent<Rigidbody>();
        instBulletRb.AddRelativeForce(transform.forward * Time.deltaTime * 100000); 

    }

    void    ShootLaser()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, range))
        {
            if (hitInfo.transform.name == "EnemyOne(Clone)")
            {
                hitInfo.transform.GetComponent<EnemyControllers>().TakeDamage(1);
            }
        }
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;
        while (Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            line.SetPosition(0, ray.origin);
            if (Physics.Raycast(ray, out hit, 100))
            {
                line.SetPosition(1, hit.point);
                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(transform.forward * 10, hit.point);
                }
            }
            else
                line.SetPosition(1, ray.GetPoint(100));

            yield return null;
        }

        line.enabled = false;
    }
}
