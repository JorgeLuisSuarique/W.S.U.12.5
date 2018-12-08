using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed = 1f;
    public float rangoVicion;
    public float rangoDisparar;
    public Transform target;
    public bool isRight;
    public Vector3 the, end;

    public GameObject bullPrefab;
    public Transform bullSpawner;
    public float attackSpeed = 1f;
    bool attacking;

    private Rigidbody2D rb2d;
    private Animator anim;
    Vector3 initialPosition, Enemy;
    GameObject player;

    void Start()
    {
        if (target != null)
        {
            target.parent = null;
            the = transform.position;
            end = target.position;
        }

        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = new Vector3
        {
            x = -62.3f,
            y = -3.27f,
            z = 0
        };

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

    void TargetDetection()
    {
        Enemy = initialPosition;

        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, player.transform.position - transform.position, rangoVicion);

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.tag == "Player")
            {
                Enemy = player.transform.position;
                Debug.Log("0");
            }
        }

        float dintance = Vector3.Distance(Enemy, transform.position);
        Vector3 direction = (Enemy - transform.position).normalized;

        if (Enemy != initialPosition && dintance < rangoDisparar)
        {
            if (!attacking) StartCoroutine(Attack(attackSpeed));
        }
        else
        {
            rb2d.MovePosition(transform.position + direction * speed * Time.deltaTime);
            Idle();
        }
        

        Debug.DrawLine(transform.position, Enemy, Color.blue);
    }

    void Update()
    {
        if (Pausa.isPause)
        {
            return;
        }
        else
        {
          TargetDetection();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoVicion);
        Gizmos.DrawWireSphere(transform.position, rangoDisparar);
    }

    IEnumerator Attack(float seconds)
    {
        attacking = true;
        if (Enemy != initialPosition && bullPrefab != null)
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
}
