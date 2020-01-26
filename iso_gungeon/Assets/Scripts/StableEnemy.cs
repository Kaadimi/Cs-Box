using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StableEnemy : MonoBehaviour
{
    public bool isDead = false;
    public float health = 3f;
    Transform target;    
    public Image forGround;

    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemie;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).transform.LookAt(Camera.main.transform);
        transform.LookAt(target.transform);
        checkEnemy();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        forGround.fillAmount = health / 3;
        if (health <= 0f)
        {
            isDead = true;
        }
    }

    void    checkEnemy()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].GetComponent<StableEnemy>().isDead)
            {
                Destroy(enemies[i]);
                enemies.RemoveAt(i);
            }
        }
    }
}