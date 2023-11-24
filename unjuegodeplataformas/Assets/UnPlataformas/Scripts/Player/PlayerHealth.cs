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
        // Si el jugador es invulnerable, no procesar el da�o.
        if (isInvulnerable) return;

        currentHealth -= damage;

        // Iniciar la invulnerabilidad temporal.
        StartCoroutine(BecomeInvulnerable());

        // L�gica adicional al recibir da�o (animaciones, sonidos, etc.).
        ReactToDamage();

        // Si la salud llega a cero, ejecutar la l�gica de muerte.
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    protected override void Die()
    {
        // Desactivar el controlador del personaje.
        controller.enabled = false;

        // Reproducir sonido de muerte.
        GameManager.Instance.soundManager.PlaySound(Audios.playerDie);

        // Verificar si el objeto del juego sigue activo antes de continuar.
        if (!gameObject.activeInHierarchy) return;

        // Iniciar animaci�n de muerte y manejar eventos posteriores.
        StartCoroutine(animations.OnDeath(animEnded => {
            GameManager.Instance.OnGameOver(true);
        }));
    }

    private void ReactToDamage()
    {
        // Devolvemos al jugador a su tama�o original
        if (currentHealth == 1) transform.localScale = new Vector3(1, 1, 1);

        
        collisions.SetLevelUp(false);
        animations.OnHurt();

        // Reproducir sonido de da�o.
        GameManager.Instance.soundManager.PlaySound(Audios.playerHit);
    }

    public void OnDie()
    {
        Die();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void GetLevelUp()
    {
        currentHealth = 2;
    }

    // Corrutina para manejar la invulnerabilidad temporal del jugador.
    private IEnumerator BecomeInvulnerable()
    {
        isInvulnerable = true;

        // Esperar un tiempo espec�fico antes de desactivar la invulnerabilidad.
        yield return new WaitForSeconds(invulnerabilityTime);

        isInvulnerable = false;
    }
}
