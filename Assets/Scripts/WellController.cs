using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("stay");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player is refueling water");

            //add to water
            //characterStats.SpendWater();
            var charStats = collision.gameObject.GetComponent<CharacterStats>();
            if (charStats)
            {
                charStats.ReloadWater();
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("exit");
    }
}
