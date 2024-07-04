using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int maxHealth;
    public int currentHealth;
    public int attackPower;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Attack(Character target)
    {
        target.TakeDamage(attackPower);
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
