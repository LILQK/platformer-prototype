using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    private bool hasJumped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Aplicar una fuerza inicial hacia arriba para el salto
        rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

        // Elegir una dirección aleatoria: izquierda (-1) o derecha (1)
        int direction = Random.Range(0, 2) * 2 - 1; // Esto dará -1 o 1
        movementDirection = new Vector2(direction, 0);
    }

    void Update()
    {
        if (!hasJumped)
        {
            if (Mathf.Abs(rb.velocity.y) < 0.01f) // Verificar si el objeto ha dejado de subir
            {
                hasJumped = true;
            }
        }
        else
        {
            // Mover el objeto en la dirección elegida una vez que ha terminado el salto
            rb.velocity = new Vector2(movementDirection.x * speed, rb.velocity.y);
        }
    }
}
