﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControllers : MonoBehaviour
{
    // Start is called before the first frame update
    public float bombRadius = 5f;
    public bool isDead = false;
    public float health = 3f;
    public float distance;
    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);

        if (distance >= bombRadius)
        {
            agent.SetDestination(target.position);
        }
        else
        {
            StartCoroutine(ExplosionRaduis());
        }    
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            isDead = true;
        }
    }

    IEnumerator ExplosionRaduis()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(1);
        if (distance < bombRadius)
        {
            isDead = true;
            if (target.GetComponent<PlayerHealth>().health > 0)
                target.GetComponent<PlayerHealth>().health--;
        }
        else
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    // void OnDrawGizmosSelected() 
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, bombRadius);
    // }
}
