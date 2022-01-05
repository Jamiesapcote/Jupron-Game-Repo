using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    //varable that are refrences to objects in our scene
    // and to the spacific componants on those objects 
    Text healthValue;
    PlayerHealth player;


    // Start is called before the first frame update
    void Start()
    {
        // get the text compnant attached to this object and store it in the varable 
        healthValue = GetComponent<Text>();
        //search the entire scene  for PlayerHealth compoent and store it in the varable 
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        //gget the current health functuon value from the player using the GetHealth function
        //change the number to text using .ToString()
        // on the health value text compnant, set the text to thebe the number we just got 
        healthValue.text = player.GetHealth().ToString();

    }
}
