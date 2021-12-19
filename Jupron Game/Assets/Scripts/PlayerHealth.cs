using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //this function is NOT built in to unity
    //it will only be called manually by our  own code
    //it must be marked "public" so our other scripts can access it 
    public void Kill()
    {
        // this will destrtoy gameObject that this script is attached to
        Destroy(gameObject);
    }






}
