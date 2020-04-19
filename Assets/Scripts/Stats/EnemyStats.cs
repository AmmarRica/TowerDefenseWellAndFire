using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxWaterSupply = 100;
    public int CurrentHealth { get; private set; }

    public Stat damage;
    public Stat armor;


    void Awake()
    {
        CurrentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Dying Animation, etc.

        //Meant to be overriden from somewhere else.
        Debug.Log(transform.name + " died.");
        Destroy(gameObject);
    }
}
