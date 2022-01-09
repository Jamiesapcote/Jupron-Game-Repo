using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{


    //public
    public float forceStrength; // how fast we move
    public Transform target; //the thing you want to chase

    //private
    private Rigidbody ourRigidbody; // the rigidbody attached to the object for movment 



    // Start is called before the first frame update

    // Awake is called whe the script first loads 
    void Awake()
    {
        // get the rigidbody  that we we,ll be using for movment 
        ourRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //move in the direction of our target


        // get the direction (as in enemy patrol)
        Vector2 direction = ((Vector2)target.position - (Vector2)transform.position).normalized;

        // move in the correct direction with the set force strength
        ourRigidbody.AddForce(direction * forceStrength);

    }
}
