using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxWaterSupply = 100;
    public float CurrentHealth { get; private set; }

    public Stat damage;
    public Stat armor;
    public float CurrentWaterSupply;

    public float waterAddRate = 0.5f;
    public float waterReduceRate = 0.5f;
    public float rate=1;

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

        CurrentHealth -= (damage );
        Debug.Log(transform.name + " takes " + damage + " damage.");
        Debug.Log("current health: " + CurrentHealth);

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
        if(CurrentWaterSupply <= maxWaterSupply)
        {
            //Debug.Log("Water Supply:" + waterSupply);
            CurrentWaterSupply= CurrentWaterSupply + (Time.deltaTime * waterAddRate);
        }
        else
        {
            Debug.Log("Water is full!");
            CurrentWaterSupply = 100;
        }
    }
    public void SpendWater()
    {
        
        if(CurrentWaterSupply <= 0)
        {
            Debug.Log("Water is Empty!");
            CurrentWaterSupply = 0;
        }
        else
        {
                CurrentWaterSupply = CurrentWaterSupply - (Time.deltaTime * waterReduceRate);
                //Debug.Log("Water is: " + waterSupply);
        }
    }

    public bool PlayerCanShoot()
    {
        if(CurrentWaterSupply > 0) { return true; }
        else
        {
            return false;
        }
    }
}
