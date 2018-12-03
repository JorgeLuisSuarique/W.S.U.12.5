using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float rangoDisparar;
    GameObject player;
    Animator anim;

    public GameObject bullPrefab;
    public Transform bullSpawner;
    public float attackSpeed = 1f;
    bool attacking;

    Vector3 initialPosition, Enemy;

    void Start()
    {
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Enemy = initialPosition;
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, player.transform.position - transform.position, rangoDisparar);
        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);
        if (hit2D.collider != null)
        {
            Enemy = player.transform.position;
        }
        float dintance = Vector3.Distance(Enemy, transform.position);
        Vector3 direction = (Enemy - transform.position).normalized;
        if (Enemy != initialPosition && dintance < rangoDisparar)
        {
            Debug.Log("disparando");
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }
        if (Enemy == initialPosition && dintance < 0.02f)
        {
            transform.position = initialPosition;
        }
        Debug.DrawLine(transform.position, Enemy,Color.green);
    }

    IEnumerator Attack(float seconds)
    {
        attacking = true;
        if ( bullPrefab != null)
        {
            Instantiate(bullPrefab, bullSpawner.position, bullSpawner.rotation);
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BlasterDestroy"))
        {
            Destroy(gameObject);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDisparar);
    }
}