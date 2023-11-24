using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCollisionDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerHealth playerHealth;

    [SerializeField] private PolygonCollider2D bounds; //Referencia de colision externa

    public float threshHold;

    //Referencia de tile map del suelo y sus tipos de bloques especiales
    public Tilemap tilemap;
    public TileBase breakableTile;
    public TileBase questionTile;
    public TileBase usedTile;

    private bool isLevelUp;
    public bool IsLevelUp => isLevelUp;
    public bool SetLevelUp(bool l) => isLevelUp = l;

    [SerializeField] private ParticleSystem hitParticle;
    [SerializeField] private CoinScript coin;
    [SerializeField] private GameObject mushroom;
    [SerializeField] private GameObject flash;

    // Diccionario para almacenar si un tile ya ha dado recompensa
    private Dictionary<Vector3Int, bool> rewardGiven = new Dictionary<Vector3Int, bool>();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Comrpobamos por tag con que hemos colisionado

        CheckIfIsEnemy(collision);

        CheckIfIsGround(collision);

        CheckIfIsMushroom(collision);
    }

    private void CheckIfIsEnemy(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Comprobamos si el jugador esta encima del enemigo
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

    private void CheckIfIsGround(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Comprobamos si chocamos contra el suelo
        {
            foreach (ContactPoint2D hit in collision.contacts)
            {
                Vector3 hitPosition = Vector3.zero;
                if (hit.normal.y < -0.5) // Verifica si el golpe viene desde abajo
                {
                    //Este trozo de codigo convierte un punto de colision en un punto en el tilemap
                    //Referencia: https://github.com/Unity-Technologies/2d-techdemos/blob/master/Assets/Tilemap/Brick/Scripts/Ball.cs

                    hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                    hitPosition.y = hit.point.y - 0.01f * hit.normal.y;

                    hitParticle.transform.position = hit.point;
                    hitParticle.Play();

                    HandleBlockHit(hitPosition);//Funcion para gestionar el golpe segun el bloque
                }
            }
        }
    }

    private void CheckIfIsMushroom(Collision2D collision)
    {
        if (isLevelUp) return;

        if (collision.gameObject.CompareTag("Mushroom"))
        {
            playerHealth.GetLevelUp();//Subimos de nivel al jugador

            Instantiate(flash,transform); // Instanciamos efectos visuales

            isLevelUp = true;
            transform.localScale = transform.localScale * 1.5f; // Aumentamos tamaño
            Destroy(collision.gameObject);
        }
    }

    void HandleBlockHit(Vector2 hitPoint)
    {
        Vector3Int tilePosition = tilemap.WorldToCell(hitPoint); // Obtenemos la posicion de celda
        TileBase hitTile = tilemap.GetTile(tilePosition); // Obtenemos tipo de Tile

        if (hitTile == null) return;

        if (hitTile.name != usedTile.name && CheckIfRewardedTile(hitTile))
        { //Si la Tile no es un bloque usado
            int reward = 0;

            if (hitTile.name == questionTile.name)
            {
                reward = Random.Range(1, 3) % 2 == 0 ? 1 : 0; // Probabilidad del 50% de obtener seta o moneda

                tilemap.SetTile(tilePosition, usedTile); // Cambiar a bloque usado
            }
            else if (hitTile.name == breakableTile.name)
            {
                if (isLevelUp)
                {
                    tilemap.SetTile(tilePosition, null);
                }
                else
                {
                    reward = 0;
                }
                // Activar lógica para monedas o potenciadores
            }
            if (!HasRewardBeenGiven(tilePosition))
            {

                ActivateReward(hitPoint, reward);
                MarkRewardAsGiven(tilePosition);
            }
        }
    }

    private bool CheckIfRewardedTile(TileBase hitTile)
    {
        return (hitTile.name == questionTile.name || hitTile.name == breakableTile.name);
    }

    void ActivateReward(Vector2 tilePosition,int reward)
    {
        if (reward == 0) //Si es 0 es una moneda
        {
            UIData.Instance.AddCoin();
            coin.Activate(tilePosition);
        }
        else { // Sino es una seta

            //Spawneamos la seta encima de la Tile
            Vector2 spawnPos = tilePosition;
            spawnPos.y += 1.5f;
            GameObject _mushroom = Instantiate(mushroom, spawnPos, Quaternion.identity);
        }
    }

    private bool IsPlayerOnTop(Collision2D collision)
    {
        Debug.Log(transform.position.y - collision.transform.position.y);
        // Comparar la posición en Y del jugador con la del enemigo
        return rb.velocity.y <= 0 && transform.position.y - collision.transform.position.y > threshHold; //Si el jugador esta cayendo y la posicion es superior entonces esta encima
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Si el jugador se sale de los limites muere
        if (collision == bounds)
        {
            GetComponent<PlayerHealth>().OnDie();
        }
    }

    // Verificar si un tile ya ha dado recompensa
    private bool HasRewardBeenGiven(Vector3Int position)
    {
        return rewardGiven.ContainsKey(position) && rewardGiven[position];//Comprueba si en el diccionario esa celda esta marcada como ya usada
    }

    private void MarkRewardAsGiven(Vector3Int position)
    {
        //Añade al diccionario la posicion y la marca como usada
        if (!rewardGiven.ContainsKey(position))
        {
            rewardGiven.Add(position, true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Flag")) {
            GameManager.Instance.OnGameOver(false); // Si toca la bandera del final acaba sin morir
        }
    }
}
