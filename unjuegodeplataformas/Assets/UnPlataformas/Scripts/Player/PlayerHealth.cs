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
    // Implementaci�n del m�todo TakeDamage
    public override void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
        StartCoroutine(animations.OnDeath(animEnded => {
            GameManager.Instance.OnGameOver(false);
        }));
        // Opcional: reiniciar el nivel o llevar a cabo otras acciones despu�s de la muerte
    }

    // M�todo adicional para reaccionar al da�o
    private void ReactToDamage()
    {
        animations.OnHurt();
    }

    public void OnDie() {
        Die();
    }
}
