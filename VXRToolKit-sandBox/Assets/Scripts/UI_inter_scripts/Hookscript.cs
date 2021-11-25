using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookscript : MonoBehaviour
{
    public float smoothing = 1f;
   [SerializeField]
    Transform MaxRange;
    
    [SerializeField]
     GameObject lockpoint;

    public IEnumerator Fire()
    {
        while (Vector3.Distance(transform.position, MaxRange.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, MaxRange.position, smoothing * Time.deltaTime);


          
           
           
            yield return null;
        }

        

       
          

        transform.position = lockpoint.transform.position;
        
        Debug.Log("Hook transform done");
         

    }

     /*   void OnTriggerEnter(Collider other) //when another collider passes through
    {
        if (other.gameObject.CompareTag("Hookable"))//check for keystone tag
        {
            

        }


    }*/





}
