using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
public class ShootHook : MonoBehaviour
{
    private XRGrabInteractable grabInter;
    [SerializeField]
   GameObject hook;
   // [SerializeField]
   // GameObject lockpoint;
    //Hookscript hookscript;
   // public float hookTravelSpeed; //set the speed of the hook object
   // public float playerTravelSpeed;

   // public static bool fired;
   //public static bool hooked;

   // public float maxDistance;//how far the hook can travel
   // private float currentDistence;//where the hook is currently at
    
    /*[SerializeField]//reload action
    InputActionReference PullTrigger;
    XRBaseInteractor interactor;
    ActionBasedController actionCon;
    */

    private void Awake()
    {
        grabInter = GetComponent<XRGrabInteractable>();
       grabInter.activated.AddListener(HookShot);
       // PullTrigger.action.started += HookShot;
    }

   private void HookShot(ActivateEventArgs arg0)
    {
       
        StartCoroutine(hook.GetComponent<Hookscript>().Fire());
/*
         //this needs to be a coroutine to stop the incremental crawl 
        hook.transform.Translate(Vector3.back * Time.deltaTime * hookTravelSpeed);
        currentDistence = Vector3.Distance(transform.position, hook.transform.position);
        if (currentDistence >= maxDistance)
        { RertunHook(); }
       // Debug.Log("hook fired");*/

    }

   /*IEnumerator Fire (Transform hook)
    {

       hook.transform.Translate(Vector3.back * hookTravelSpeed * Time.deltaTime ); 
        currentDistence = Vector3.Distance(transform.position, hook.transform.position);

        if (currentDistence >= maxDistance)
        {
            RertunHook();
        } 

        yield break;
    }*/

   /* private void RertunHook()
    {
        hook.transform.position = lockpoint.transform.position;
    }*/
}
