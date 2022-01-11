using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorePickUp : MonoBehaviour
{
    public int pickupvalue = 1;

    //called by unity when this object overlaps with snother object marked as a trigger 
    
     void OnTriggerEnter(Collider other)
    {
        Score scoreScript = other.GetComponent<Score>();

        if (scoreScript !=null)
        {

            scoreScript.addScore(pickupvalue);


            Destroy(gameObject);


        }
    }
}
