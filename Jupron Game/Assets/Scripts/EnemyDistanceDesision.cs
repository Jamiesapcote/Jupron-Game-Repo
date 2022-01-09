using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDistanceDesision : MonoBehaviour
{
    //public (editable in unity)
    public float distanceForDecision; // how close the player must be to chage behavour
    public Transform target;

    //private
    private EnemyPetrol patrolBehaviour;
    private EnemyChase chaseBehaviour;




    // Start is called before the first frame update
    void Awake()
    {
        //GET the behaviors so we can turn them off and on
        patrolBehaviour = GetComponent<EnemyPetrol>();
        chaseBehaviour = GetComponent<EnemyChase>();

        // turn of chase behavour to start wiht 

        chaseBehaviour.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //how far are we from our target?
        float distance = ((Vector2)target.position - (Vector2)transform.position).magnitude;


        // if we are close to our target our minimum distance 
        if (distance <= distanceForDecision)
        {
            //desable patrol and enable chasing 
            patrolBehaviour.enabled = false;
            chaseBehaviour.enabled = true;
        }

        else
        {
            // enable patrol and disable chasing 
            patrolBehaviour.enabled = true;
            chaseBehaviour.enabled = false;
        }
    }
}
