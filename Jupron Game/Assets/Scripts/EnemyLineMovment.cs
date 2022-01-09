using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLineMovment : MonoBehaviour
{
    //public varables 
    //exposed for editing in the unity editor 
    public float forceStrength; // how hard the script pushes the
                                // enemy aka how fast the enemy moves
    // what direction the enemy should move in
    public Vector2 direction;

    //private varables 
    // not visable in editor
    // used for tracking data while the game is running
    private Rigidbody ourRigidbody;
    //the container for the rigidbody
    //atached to the object

    // Awake is called when the script is first loaded 
    void Awake()
    {
        //get and store the rigidbody we'll be using for movment 
        ourRigidbody = GetComponent<Rigidbody>();

        // normalizse our direction
        //normalise changes it to be length 1, so we can multiply
        //it by our speed / force later
        direction = direction.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        // move in the correct direction with the set force strength
        ourRigidbody.AddForce(direction * forceStrength);
    }
}
