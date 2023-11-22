using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    [SerializeField] private PolygonCollider2D bounds;
    public float threshHold;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Comprobar si Mario está por encima del enemigo
            if (IsPlayerOnTop(collision))
            {
                // Dañar al enemigo
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
            }
            else
            {
                // El jugador recibe daño
                playerHealth.TakeDamage(1);
            }
        }
    }

    private bool IsPlayerOnTop(Collision2D collision)
    {
        Debug.Log(transform.position.y - collision.transform.position.y);
        // Comparar la posición en Y del jugador con la del enemigo
        return rb.velocity.y <= 0 && transform.position.y - collision.transform.position.y > threshHold;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == bounds)
        {
            GetComponent<PlayerHealth>().OnDie();
        }
    }
}
