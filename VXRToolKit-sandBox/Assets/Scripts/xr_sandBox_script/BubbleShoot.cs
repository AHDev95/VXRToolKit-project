using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.InputSystem;

public class BubbleShoot : MonoBehaviour
{
    private XRGrabInteractable grabInter;
    [SerializeField]
    GameObject bubblePrefab;
    [SerializeField]
    Transform spawnPoint;
    private int BubbleAmmo = 10;
    [SerializeField]
    private TextMeshProUGUI ammoText;

    [SerializeField]//reload action
    InputActionReference reloadAction;
    XRBaseInteractor interactor;
    ActionBasedController actionCon;

    // Start is called before the first frame update
    void Awake()
    {
        grabInter = GetComponent<XRGrabInteractable>();
        grabInter.activated.AddListener(SpawnBubbles);
        reloadAction.action.started += Reload;
    }
    public void GetInteractor()
    {
        interactor = grabInter.selectingInteractor;
    }

    public void ReleaseInteractor()
    {
        interactor = null;
    }

    private void Reload(InputAction.CallbackContext obj)
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            BubbleAmmo = 10;
            ammoText.text = BubbleAmmo.ToString();
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            BubbleAmmo = 10;
            ammoText.text = BubbleAmmo.ToString();
        }
    }

    private void SpawnBubbles(ActivateEventArgs arg0)
    {
        if (BubbleAmmo > 0) 
        { 
        Instantiate(bubblePrefab,spawnPoint.position, Quaternion.identity);
            BubbleAmmo --;
            ammoText.text = BubbleAmmo.ToString();
        }
    }

    
}
