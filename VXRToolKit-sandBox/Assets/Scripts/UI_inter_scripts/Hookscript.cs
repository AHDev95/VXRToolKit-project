using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookscript : MonoBehaviour
{
   //public float smoothing = 1f;
  // [SerializeField]
   // Transform MaxRange;
    //[SerializeField]
    //GameObject XRRig;
    [SerializeField]
     GameObject lockpoint;
    //bool Hit = false;
   // bool resetHook = true;
    WaitForSeconds delay = new WaitForSeconds(2);
    [SerializeField]
    Rigidbody hookBody;
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject gun;
   // WaitForSeconds fireTime = new WaitForSeconds(3);
    //[SerializeField] int hangTime = 70;
    public void fire()
    {
        gameObject.transform.parent = null;
        hookBody.isKinematic = false;
        hookBody.AddForce( -gun.transform.forward * speed, ForceMode.Impulse);

        StartCoroutine(fireTimer());
        Debug.Log("end of fire function");
    }

    /* public IEnumerator Fire()
     {
        // resetHook = false;
         while (Vector3.Distance(transform.position, MaxRange.position) > 0.05f)
         {
             transform.position = Vector3.Lerp(transform.position, MaxRange.position, smoothing * Time.deltaTime);


           if (Hit)
             {

                 yield return new WaitUntil(Reset);
                 Debug.Log("stoped fire coroutine");
                 yield break;
               if hit = true wait until "xr rig has moved" then return hook
                  to lock point and yeild break
             }


             yield return null;
         }

         transform.position = lockpoint.transform.position;
         Debug.Log("Hook transform done");
     }*/




    void OnCollisionEnter(Collision other) //when another collider passes through
    {
        if (other.gameObject.CompareTag("Hookable"))//check for keystone tag
        {
           // Debug.Log("hit");
        hookBody.velocity = Vector3.zero;
           
            StartCoroutine(HookableWall());
        /*if (other.gameObject.CompareTag("Hookable"))//check for keystone tag
        {
            Hit = true;
            StartCoroutine(HookableWall());*/
        } 
        else if(other.gameObject.CompareTag("NotHookable"))
        {
           
            StartCoroutine(wall());
        }
        





    }

    public IEnumerator fireTimer()
    {   //Debug.Log("start reset");
        yield return delay;
        
        if (transform.position != lockpoint.transform.position)
        {   
            
           
            hookBody.isKinematic = true;
            transform.position = lockpoint.transform.position;
            transform.rotation = lockpoint.transform.rotation;
            gameObject.transform.parent = gun.transform;
            
        }
        //Debug.Log(" reset");
        yield break;
    }

    public IEnumerator HookableWall()
    {   StopCoroutine(fireTimer());
         hookBody.isKinematic = true;
        yield return delay;
         
       
        if (transform.position != lockpoint.transform.position)
        {    
           
            
            transform.position = lockpoint.transform.position;
            transform.rotation = lockpoint.transform.rotation;
            gameObject.transform.parent = gun.transform;
             
            // resetHook = true;
            // Hit = false;
            // StopCoroutine("Fire");
        }
        //Debug.Log("Hit hookable wall");
        yield break;
    }

    public IEnumerator wall()
    {    StopCoroutine(fireTimer());
        hookBody.isKinematic = true;
        if (transform.position != lockpoint.transform.position)
        {
            
            
            transform.position = lockpoint.transform.position;
            transform.rotation = lockpoint.transform.rotation;
            gameObject.transform.parent = gun.transform;
            
            // resetHook = true;
            // Hit = false;
            // StopCoroutine("Fire");
        }
       // Debug.Log("Hit wall");
        yield return null;
    }

    /*bool Reset()
    {
        if (!resetHook) 
        { 
            return false;
        }
        else
        {
            return true;
        }
    }*/


}
