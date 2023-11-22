using UnityEngine;

// Clase abstracta que define un sistema de vida
public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth; // M�xima salud
    [SerializeField]
    protected int currentHealth; // Salud actual

    // M�todo para inicializar la salud
    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    // M�todo abstracto para manejar la recepci�n de da�o
    public abstract void TakeDamage(int damage);

    // M�todo para curar
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHeal(healingAmount); // M�todo opcional para responder a la curaci�n
    }

    // M�todo abstracto que se llama cuando el personaje muere
    protected abstract void Die();

    // M�todo opcional para responder a la curaci�n
    protected virtual void OnHeal(int healingAmount)
    {
        // Implementar l�gica espec�fica, como efectos visuales o sonoros
    }
}
