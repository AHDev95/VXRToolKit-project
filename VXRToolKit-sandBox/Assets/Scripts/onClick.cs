using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onClick : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    guessManager GuessScript;

    
    //public int identity;
    private void Start()
    {
       
        GuessScript = GameObject.Find("guesslog").GetComponent<guessManager>();
        

        
    }

    void OnMouseDown()
    {

        gameObject.GetComponent<GameObject>();
        GuessScript.guess[GuessScript.count] = gameObject.GetComponent<GameObject>();
        GuessScript.count++;


    }

   
}
