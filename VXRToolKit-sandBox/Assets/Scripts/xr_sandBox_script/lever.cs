using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    HingeJoint hinge;
    [SerializeField]
    GameObject BubbleGun;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hinge.angle == hinge.limits.min)
        {
            BubbleGun.SetActive(true);
        }
    }
}
