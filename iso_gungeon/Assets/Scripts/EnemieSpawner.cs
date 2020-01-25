using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public List<GameObject> en = new List<GameObject>();
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    int randEnemy;
    int MaxEnemies = 4;
    Vector3 spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
       // spawnPosition = GameObject.FindWithTag("Spawner").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
        checkEnemy();
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds (startWait);
        
        for (int i = 0; i < MaxEnemies; i++)
        {
            randEnemy = Random.Range(0, 2);

            en.Add(Instantiate (enemies[randEnemy], transform.position , gameObject.transform.rotation));

            yield return new WaitForSeconds (spawnWait);
        }
    }

    void    checkEnemy()
    {
        for (int i = 0; i < en.Count; i++)
        {
            if (en[i].GetComponent<EnemyControllers>().isDead)
            {
                Destroy(en[i]);
                en.RemoveAt(i);
            }
        }
    }
}
