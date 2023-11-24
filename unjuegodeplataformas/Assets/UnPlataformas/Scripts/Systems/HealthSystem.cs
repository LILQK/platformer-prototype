using UnityEngine;

// Clase abstracta que define un sistema de vida
public abstract class HealthSystem : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth; // Saludo maxima
    [SerializeField]
    protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public abstract void TakeDamage(int damage);

    //Metodo para curar
    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    protected abstract void Die();//Metodo abstracto de muerte

}
