using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUP(string text)

    { 
       popUpBox.SetActive(true);
       popUpText.text = text;
       animator.SetTrigger("pop");

    }

    public PopUpSystem factPopUp; //move this to part code 
    
    
}
