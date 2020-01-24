using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    public GameObject firePoint;
    public CharController newRotation;
    private float timeToFire = 0;
    void Start()
    {        
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<MoveProjectile>().fireRate;
            spawVFX();
        }
    }

    void    spawVFX()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            //Physics.IgnoreCollision(vfx.GetComponent<Collider>(), newRotation.GetComponent<Collider>());
            if (newRotation != null)
            {
                vfx.transform.localRotation = newRotation.GetRotation();
            }
        } else {
            Debug.Log("No Fire Point");
        }
    }
}
