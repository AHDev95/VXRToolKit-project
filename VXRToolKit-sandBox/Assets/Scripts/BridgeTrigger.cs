using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    [SerializeField] GameObject bridge;
    
    private void OnTriggerStay(Collider other)
    {
        bridge.GetComponent<Rigidbody.>();
    }
}
