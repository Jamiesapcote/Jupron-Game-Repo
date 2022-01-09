using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderDisplay : MonoBehaviour
{
    // this will contain the slider companant attaced to this object
    // slider = varable is in the form of the slider component 
    Slider healthBar;

    //this will be the PlayerHealth component that we can ask for 
    //info about the player's health
    PlayerHealth player;


    // Start is called before the first frame update
    void Start()
    {
        //getting the slider comonent off THIS game object 
        // the one this script is attached to)
        //and storing it in the healthBar varable 
        healthBar = GetComponent<Slider>();

        //search the entire scene for the PlayerHealth component 
        //and sote it in the player varable
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //create temporary float varables 
        //so we can use float division
        float currentHealth = player.GetHealth();
        float maxHealth = player.startingHealth;
        //the slider value should be between 0 and 1,
        //with 0 being empty and 1 being full
        //we devide the current health by the max health to get 
        //a number between 0 and .
        healthBar.value = currentHealth / maxHealth;

    }
}
