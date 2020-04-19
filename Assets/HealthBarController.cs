using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public  GameObject charachter;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (charachter == null) {
            image.fillAmount = 0;
            return; }


        var stats = charachter.GetComponent<CharacterStats>();
        if (stats)
        {

            image.fillAmount =  stats.CurrentHealth / stats.maxHealth;
        }
    }

}
