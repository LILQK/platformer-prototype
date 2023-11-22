using UnityEngine;

// Clase abstracta que define un sistema de vida
public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth; // Máxima salud
    [SerializeField]
    protected int currentHealth; // Salud actual

    // Método para inicializar la salud
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    // Método abstracto para manejar la recepción de daño
    public abstract void TakeDamage(int damage);

    // Método para curar
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHeal(healingAmount); // Método opcional para responder a la curación
    }

    // Método abstracto que se llama cuando el personaje muere
    protected abstract void Die();

    // Método opcional para responder a la curación
    protected virtual void OnHeal(int healingAmount)
    {
        // Implementar lógica específica, como efectos visuales o sonoros
    }
}
