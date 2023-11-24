using UnityEngine;

public class EnemyHealth : HealthSystem
{
    private IAnimations animations;
    private BoxCollider2D _collider;
    private Rigidbody2D rb;
    private void Start()
    {
        animations = GetComponentInChildren < EnemyAnimations > ();
        _collider = GetComponent<BoxCollider2D> ();
        rb = GetComponent<Rigidbody2D> ();
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

        GameManager.Instance.soundManager.PlaySound(Audios.enemyDie);
        _collider.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(animations.OnDeath(animEnded => {
            if (animEnded) {

                UIData.Instance.AddPoints(100);

                // Destruir o desactivar el enemigo
                Destroy(gameObject);
            }
        }));

    }

    // M�todo adicional para reaccionar al da�o
    private void ReactToDamage()
    {
        GameManager.Instance.soundManager.PlaySound(Audios.enemyHit);
    }
}
