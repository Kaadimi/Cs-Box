using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyControllers : MonoBehaviour
{
    public float bombRadius = 5f;
    public bool isDead = false;
    public float health = 3f;
    public float distance;
    Transform target;
    NavMeshAgent agent;
    public Image forGround;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.position, transform.position);
        transform.GetChild(0).transform.LookAt(Camera.main.transform);
        if (agent.speed == 0)
        {
            transform.LookAt(target.position);
            if (health == 0)
                Destroy(gameObject);
        }

        //Debug.Log(healthSlider);
        //healthSlider.transform.position = transform.position + new Vector3(0f, 2f, 0f);

        if (distance >= bombRadius) {
            agent.SetDestination(target.position);
        } else {
            StartCoroutine(ExplosionRaduis());
        }    
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

    IEnumerator ExplosionRaduis()
    {
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(1);
        if (distance < bombRadius)
        {
            isDead = true;
            if (target.GetComponent<PlayerHealth>().health > 1)
                target.GetComponent<PlayerHealth>().health--;
            else
                SceneManager.LoadScene(4);
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
