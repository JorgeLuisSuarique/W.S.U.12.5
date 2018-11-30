using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float rangoDisparar;

    public GameObject bullPrefab;
    public Transform bullSpawner;
    public float attackSpeed = 1f;
    bool attacking;

    Vector3 Enemy;

    void Update()
    {
        float dintance = Vector3.Distance(Enemy, transform.position);
        Vector3 direction = (Enemy - transform.position).normalized;
        if (
            dintance < rangoDisparar)
        {
            Debug.Log("disparando");
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }
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