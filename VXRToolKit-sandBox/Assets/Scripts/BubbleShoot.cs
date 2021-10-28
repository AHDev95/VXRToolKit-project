using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


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
    // Start is called before the first frame update
    void Awake()
    {
        grabInter = GetComponent<XRGrabInteractable>();
        grabInter.activated.AddListener(SpawnBubbles);
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
