using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootHook : MonoBehaviour
{
    private XRGrabInteractable grabInter;
    [SerializeField]
    GameObject hook;
    [SerializeField]
    GameObject lockpoint;

    public float hookTravelSpeed; //set the speed of the hook object
    public float playerTravelSpeed;

   // public static bool fired;
   //public static bool hooked;

    public float maxDistance;//how far the hook can travel
    private float currentDistence;//where the hook is currently at

   

    private void Awake()
    {
        grabInter = GetComponent<XRGrabInteractable>();
        grabInter.activated.AddListener(HookShot);
      
    }

    private void HookShot(ActivateEventArgs arg0)
    {
        hook.transform.Translate(Vector3.back * Time.deltaTime * hookTravelSpeed);
        currentDistence = Vector3.Distance(transform.position, hook.transform.position);

        if (currentDistence >= maxDistance)
        {
            RertunHook();
        }
           
        
       // Debug.Log("hook fired");

    }

    private void RertunHook()
    {
        hook.transform.position = lockpoint.transform.position;
    }
}
