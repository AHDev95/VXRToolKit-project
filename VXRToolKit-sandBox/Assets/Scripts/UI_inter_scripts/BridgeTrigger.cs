using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] Rigidbody bridge; //drop the bridge in here so we can interact  
                                        //with the rigidbodys Kinematic settings

    private void OnTriggerEnter(Collider other) //when another collider passes through
    {
        if (other.gameObject.CompareTag("KeyStone"))//check for keystone tag
        { 
            bridge.isKinematic = false;//change the kinematic state to off

        }

        
    }
}
