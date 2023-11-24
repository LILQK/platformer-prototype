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

    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die(); // Llamar a Die si la salud llega a cero
        }
        else
        {
            //Reaccionar al recibir daño si no muere
            ReactToDamage();
        }
    }

    protected override void Die()
    {

        GameManager.Instance.soundManager.PlaySound(Audios.enemyDie);

        _collider.enabled = false; 

        rb.bodyType = RigidbodyType2D.Static; //Deshabilitamos las fisicas para que no caiga del mapa

        StartCoroutine(animations.OnDeath(animEnded => {
            if (animEnded) {

                UIData.Instance.AddPoints(100);

                // Destruir  el enemigo
                Destroy(gameObject);
            }
        }));

    }

    private void ReactToDamage()
    {
        GameManager.Instance.soundManager.PlaySound(Audios.enemyHit);
    }
}
