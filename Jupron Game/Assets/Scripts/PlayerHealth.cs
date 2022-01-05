using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //this will be a starting health for the player 
  //public means that it is shown in the unity and accseable from other sctrpts

    public int startingHealth;
    //this will be the players current health 
    //and will change as the game goes on 
    int currentHealth;

    //built in unity function called when the script is created 
    //usally when the game starts 
    // this happens BEFORE the start()
    private void Awake()
    {
        // INISUALSE or current health to the equal to our 
        //starting health at the beginning of the game 
        currentHealth = startingHealth;

    }
    //Not built into unity we must call it our self 
    //this will change the players current health
    //and KILL() then if they 0 health or less
    //public so other scrits can access it 
    public void ChangeHealth(int changeAmount)
    {
        //take our current health, add the change amount,
        //and store the result back in the current health varable 
        currentHealth = currentHealth + changeAmount;
        // keep our current health between 0 and 100
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        //if our health dorops to 0, that means the player should die
        if (currentHealth == 0)
        {
            //We called the KILL function to the player 
            Kill();
        }

    }

    //this function is NOT built in to unity
    //it will only be called manually by our  own code
    //it must be marked "public" so our other scripts can access it 
    public void Kill()
    {
        // this will destrtoy gameObject that this script is attached to
        Destroy(gameObject);
    }

    //getter function to give information to the calling code 
    // the int meanas that an interger (whole number) will be givin back 
    // the return is what will be givin back 
    public int GetHealth()
    {
        return currentHealth;
    }

}
