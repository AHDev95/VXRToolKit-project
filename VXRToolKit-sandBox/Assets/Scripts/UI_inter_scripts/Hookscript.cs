using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookscript : MonoBehaviour
{
    public float smoothing = 1f;
   [SerializeField]
    Transform MaxRange;
    //[SerializeField]
    //GameObject XRRig;
    [SerializeField]
     GameObject lockpoint;
    bool Hit = false;
    bool resetHook = true;
    public IEnumerator Fire()
    {
        resetHook = false;
        while (Vector3.Distance(transform.position, MaxRange.position) > 0.05f)
        {
            transform.position = Vector3.Lerp(transform.position, MaxRange.position, smoothing * Time.deltaTime);


          if (Hit)
            {
                
                yield return new WaitUntil(Reset);
                
                //transform.position = lockpoint.transform.position;
                //resetHook = true;
               Debug.Log("stoped coroutine");
               // StopCoroutine("Fire");
                /*if hit = true wait until "xr rig has moved" then return hook
                 to lock point and yeild break*/
            }
           
           
            yield return null;
        }







        transform.position = lockpoint.transform.position;
        Debug.Log("Hook transform done");
         

    }
    
    
    

       void OnTriggerEnter(Collider other) //when another collider passes through
    {
        if (other.gameObject.CompareTag("Hookable"))//check for keystone tag
        {
            Hit = true;
            StartCoroutine(HookableWall());
        } /**/
    }

    public IEnumerator HookableWall()
    {

        if (transform.position != lockpoint.transform.position)
        {
            transform.position = lockpoint.transform.position;
            resetHook = true;
            StopCoroutine("Fire");
            Hit = false;
        }
        Debug.Log("Hit hookable wall");
        yield return null;
    }

    bool Reset()
    {
        if (!resetHook) 
        { 
            return false;
        }
        else
        {
            return true;
        }
    }


}
