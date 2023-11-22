using UnityEngine;

public class EnemyHealth : HealthSystem
{
    private IAnimations animations;
    private BoxCollider2D _collider;
    private void Start()
    {
        animations = GetComponentInChildren < EnemyAnimations > ();
        _collider = GetComponent<BoxCollider2D> ();
    }
    // Implementaci�n del m�todo TakeDamage
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); // Llamar a Die si la salud llega a cero
        }
        else
        {
            // Opcional: Reaccionar al recibir da�o si no muere
            ReactToDamage();
        }
    }

    // Implementaci�n del m�todo Die
    protected override void Die()
    {

        // L�gica de muerte del enemigo, como reproducir una animaci�n, desactivar el GameObject, etc.
        Debug.Log("La seta enemiga ha muerto");
        StartCoroutine(animations.OnDeath(animEnded => {
            if (animEnded) {
                // Destruir o desactivar el enemigo
                Destroy(gameObject);
            }
        }));

    }

    // M�todo adicional para reaccionar al da�o
    private void ReactToDamage()
    {
        // Implementar l�gica espec�fica, como un efecto visual o sonido
        Debug.Log("La seta enemiga ha recibido da�o");
    }
}
