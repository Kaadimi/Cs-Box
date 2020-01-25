using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnSpawnProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> vfx = new List<GameObject>();
    private GameObject effectToSpawn;
    public GameObject firePoint;
    //public CharController newRotation;
    private float timeToFire = 0;
    void Start()
    {        
        effectToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + 0.5f;
            EnemyShooter();
        }
    }

    void EnemyShooter()
    {
        GameObject vfx;

        if (firePoint != null)
        {
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = transform.rotation;
        } else {
            Debug.Log("No Fire Point");
        }
    }
}
