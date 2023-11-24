using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    PlayerAnimations animations;
    CharacterController2D controller;
    PlayerCollisionDetection collisions;

    private bool isInvulnerable = false;
    public float invulnerabilityTime = 2f; 
    private void Start()
    {
        animations = GetComponent<PlayerAnimations>();
        controller = GetComponent<CharacterController2D>();
        collisions = GetComponent<PlayerCollisionDetection>();
    }

    public override void TakeDamage(int damage)
    {
        if (isInvulnerable) return; // Si el jugador es invulnerable, no recibe da�o

        currentHealth -= damage;

        StartCoroutine(BecomeInvulnerable()); // Iniciar la inmunidad

        // Reaccionar al da�o, por ejemplo, reproducir una animaci�n o efecto de sonido
        ReactToDamage();

        if (currentHealth <= 0)
        {
            Die(); // Llamar a Die si la salud llega a cero
        }
    }

    // Implementaci�n del m�todo Die
    protected override void Die()
    {
        controller.enabled = false;
        GameManager.Instance.soundManager.PlaySound(Audios.playerDie);
        if (!gameObject.activeInHierarchy) return;
        StartCoroutine(animations.OnDeath(animEnded => {
            GameManager.Instance.OnGameOver(true);
        }));
    }

    // M�todo adicional para reaccionar al da�o
    private void ReactToDamage()
    {
        if (currentHealth == 1) transform.localScale = new Vector3(1, 1, 1);
        collisions.SetLevelUp(false);
        animations.OnHurt();
        GameManager.Instance.soundManager.PlaySound(Audios.playerHit);
    }

    public void OnDie() {
        Die();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();   
    }

    public void GetLevelUp() {
        currentHealth = 2;
    }


    // Corrutina para manejar el estado de inmunidad
    private IEnumerator BecomeInvulnerable()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(invulnerabilityTime); // Espera por un tiempo de inmunidad
        isInvulnerable = false;
    }
}
