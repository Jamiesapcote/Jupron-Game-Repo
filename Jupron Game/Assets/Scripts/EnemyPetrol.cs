using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPetrol : MonoBehaviour
{
    //public varables
    public float forceStrength; // how fast we move 
    public Vector2[] patrolPoints; // petrol points we will move to
    public float stopDistance;//how close we get before moving to the next petrol point

    //private varables 
    private Rigidbody ourRigidbody; // the rigidbody on this object used to move 
    private int currentPoint = 0; // index of the current point we're moviung towards 


 

    // Awake is called when the script is loaded 
    void Awake()
    {
        // get the rigidbody attached to this object for movment 
        ourRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //how far are we from our target?
        float distance = (patrolPoints[currentPoint] - (Vector2)transform.position).magnitude;

        //if we are closer to our target than our minimum distance ...
        if (distance <= stopDistance)
        {
            //.... THEN, update to the next target
            currentPoint = currentPoint + 1;

            // if we,ve gone past the end of our list ...
            //(if our current point index is eqal or bigger than 
            //the length of our list
            if (currentPoint >= patrolPoints.Length)
            {
                // ..... then, loop back to the start 
                // by setting current index to 0
                currentPoint = 0;
            }
        }


        // move in the direction of our target

        //get the direction we should move in
        // subtracting the current posititon from the target posititon
        Vector2 direction = (patrolPoints[currentPoint] - (Vector2)transform.position).normalized;
        direction = direction.normalized;

        //move in the correct direction with the set force strength 
        ourRigidbody.AddForce(direction * forceStrength);
    }
}
