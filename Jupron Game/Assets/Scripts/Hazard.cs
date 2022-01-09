using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    //this will be te amount of damage the hazerd does 
    //int means whole number 
    public int hazardDamage;


    //built-in Unity function for handling collisions 
    // this function will be called when another object bumps 
    //into the one this script is attached to 
    void OnCollisionEnter(Collision collisionData)
    {
        //get the obeject we collieder with 
        Collider objectWeCollidedWith = collisionData.collider;

        //get the player heath script attached to that obbject (if there is one)
        PlayerHealth player = objectWeCollidedWith.GetComponent<PlayerHealth>();


    //check if we actually found player health script on the oject we collided with
    // this if statment is true if the player variable is NOT null (aka empty)
        if (player != null)
        {
            //this means there WAS a playerHealth script attached to the obejct we bmped into 

            //which means this object is indeed the player 
            player.ChangeHealth(-hazardDamage);

        }

    }

}
