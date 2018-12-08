using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnFinal : MonoBehaviour
{
    public bool isRight;
    public float speed = 1f;
    public Vector3 the, end;
    public Transform target;
    public LiveEnemy live;
    public float rangoDisparar;
    public GameObject bullPrefab;
    public Transform bullSpawner;
    public float attackSpeed = 1f;

    private Rigidbody2D rb2d;
    GameObject player;
    Vector3 initialPosition, Enemy;
    bool attacking;


    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            the = transform.position;
            end = target.position;
        }
        initialPosition = transform.position;
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Pausa.isPause)
        {
          return;
        }
        else
        {
          Idle();
          TargetDetection();
        }
    }

    void TargetDetection()
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
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }
        if (Enemy == initialPosition && dintance < 0.02f)
        {
            transform.position = initialPosition;
        }
        Debug.DrawLine(transform.position, Enemy, Color.green);
    }
    void Idle()
    {
        if (isRight)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.Translate((Vector3.right * speed) * Time.deltaTime);
            if (transform.position.x >= the.x)
            {
                isRight = false;
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate((Vector3.left * speed) * Time.deltaTime);
            if (transform.position.x <= target.position.x)
            {
                isRight = true;
            }
        }
    }

    IEnumerator Attack(float seconds)
    {
        attacking = true;
        if (bullPrefab != null)
        {
            Instantiate(bullPrefab, bullSpawner.position, bullSpawner.rotation);
            yield return new WaitForSeconds(seconds);
        }
        attacking = false;
    }

    void OnTriggerEnter2D(Collider2D go)
    {
        if (go.CompareTag("BlasterDestroy"))
        {
            live.Applyvida(150);
        }

        if (live.Applyvida <= 0)
        {
            
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDisparar);
    }
}
