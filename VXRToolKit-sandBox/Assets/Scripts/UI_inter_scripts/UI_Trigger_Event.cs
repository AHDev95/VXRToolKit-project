using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Trigger_Event : MonoBehaviour
{

    [SerializeField]
    private UnityEvent UIText;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("KeyStone"))
        {
            UIText.Invoke();
        }



    }





}
