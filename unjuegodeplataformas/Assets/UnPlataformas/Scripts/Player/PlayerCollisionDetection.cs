using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCollisionDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;
    [SerializeField] private PolygonCollider2D bounds;
    public float threshHold;

    public Tilemap tilemap;
    public TileBase breakableTile;
    public TileBase questionTile;
    public TileBase usedTile;
    private bool isLevelUp;

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

        if (collision.gameObject.CompareTag("EspecialBlock"))
        {

            foreach (ContactPoint2D hit in collision.contacts)
            {
                Debug.Log("Hit con bloque especial" + " " + hit.normal.y);
                Vector3 hitPosition = Vector3.zero;
                if (hit.normal.y < -0.5) // Verifica si el golpe viene desde abajo
                {
                    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

                    HandleBlockHit(hit.point);
                }
            }
        }
    }
    void HandleBlockHit(Vector2 hitPoint)
    {
        Vector3Int tilePosition = tilemap.WorldToCell(hitPoint);
        TileBase hitTile = tilemap.GetTile(tilePosition);

        if (hitTile == questionTile)
        {
            ActivateReward(tilePosition);
            tilemap.SetTile(tilePosition, usedTile); // Cambiar a bloque usado
        }
        else if (hitTile == breakableTile && isLevelUp)
        {
            // Destruir bloque si Mario es Super
            tilemap.SetTile(tilePosition, null);
            // Activar lógica para monedas o potenciadores
        }
    }

    void ActivateReward(Vector3Int tilePosition)
    {
        // Aquí debes implementar la lógica para activar la recompensa
        // Esto podría incluir generar monedas, potenciadores, etc.
        Debug.Log("Recompensa activada en la posición: " + tilePosition);
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
