using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxWaterSupply = 100;
    public int CurrentHealth { get; private set; }

    public Stat damage;
    public Stat armor;
    public float waterSupply;

    private float timer = 0;
    
    public float waterAddRate = 0.5f;
    public float waterReduceRate = 0.5f;

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
            waterSupply= waterSupply + (Time.deltaTime * waterAddRate);
        }
        else
        {
            Debug.Log("Water is full!");
            waterSupply = 100;
        }
    }
    public void SpendWater()
    {
        timer += Time.deltaTime;
        if(waterSupply <= 0)
        {
            Debug.Log("Water is Empty!");
            waterSupply = 0;
        }
        else
        {
                waterSupply = waterSupply - (Time.deltaTime * waterReduceRate);
                Debug.Log("Water is: " + waterSupply);
        }
    }

    public bool PlayerCanShoot()
    {
        if(waterSupply > 0) { return true; }
        else
        {
            return false;
        }
    }
}
