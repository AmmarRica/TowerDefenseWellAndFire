using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxWaterSupply = 100;
    public int CurrentHealth { get; private set; }

    public Stat damage;
    public Stat armor;
    public int waterSupply;

     void Awake()
     {
        CurrentHealth = maxHealth;
     }

    // checking if damage works

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        CurrentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // Dying Animation, etc.

        //Meant to be overriden from somewhere else.
        Debug.Log(transform.name + " died.");
    }

    public void ReloadWater()
    {
        if(waterSupply <= maxWaterSupply)
        {
            Debug.Log("Water Supply:" + waterSupply);
            waterSupply++;
        }
        else
        {
            Debug.Log("Water is full!");
        }
    }
}
