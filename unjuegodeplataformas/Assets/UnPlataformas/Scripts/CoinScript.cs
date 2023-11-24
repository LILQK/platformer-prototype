using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float jumpHeight; // Altura del salto
    public float duration; // Duración del salto

    private Vector3 originalPosition;
    private bool isActivated = false;
    private float timer;

    private SpriteRenderer _renderer;
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        originalPosition = transform.position; // Guarda la posición original
    }

    void Update()
    {
        if (isActivated)
        {
            timer += Time.deltaTime;

            // Calcula la nueva posición usando una función de seno para el efecto de salto
            float newY = originalPosition.y + jumpHeight * Mathf.Sin(Mathf.PI * timer / duration);
            transform.position = new Vector3(originalPosition.x, newY, originalPosition.z);

            if (timer > duration)
            {
                // Resetea la moneda
                isActivated = false;
                timer = 0f;
                transform.position = originalPosition; // Vuelve a la posición original
                _renderer.enabled = false;
            }
        }
    }

    // Método para activar el salto de la moneda
    public void Activate(Vector2 pos)
    {
        if (!isActivated)
        {
            transform.position = pos;
            originalPosition = transform.position;
            _renderer.enabled = true;
            isActivated = true;
        }
    }
}
