using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthSystem
{
    PlayerAnimations animations;
    CharacterController2D controller;
    private void Start()
    {
        animations = GetComponent<PlayerAnimations>();
        controller = GetComponent<CharacterController2D>();
    }
    // Implementación del método TakeDamage
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Reaccionar al daño, por ejemplo, reproducir una animación o efecto de sonido
        ReactToDamage();

        if (currentHealth <= 0)
        {
            Die(); // Llamar a Die si la salud llega a cero
        }
    }

    // Implementación del método Die
    protected override void Die()
    {
        controller.enabled = false;
        StartCoroutine(animations.OnDeath(animEnded => {
            GameManager.Instance.OnGameOver(false);
        }));
        // Opcional: reiniciar el nivel o llevar a cabo otras acciones después de la muerte
    }

    // Método adicional para reaccionar al daño
    private void ReactToDamage()
    {
        animations.OnHurt();
    }

    public void OnDie() {
        Die();
    }
}
