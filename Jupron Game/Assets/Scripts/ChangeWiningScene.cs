using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeWiningScene : MonoBehaviour
{
    public string levelToLoad;

    private void OnTriggerEnter(Collider otherCollider)
    {

        if (otherCollider.tag == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
        }

    }
}
