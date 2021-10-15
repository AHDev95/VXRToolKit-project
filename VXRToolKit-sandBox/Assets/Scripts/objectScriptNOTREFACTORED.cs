using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectScriptNOTREFACTORED : MonoBehaviour
{
    // variables for color change logic
    Renderer objRenderer;
    float timer = 0f;
    [SerializeField]
    public Color[] randomColor;
    Color newColor;
    private float colorChangeTime = 5f;
    // variables for float logic
    float yPos;
    [SerializeField]
    [Range(0, 5)]
    float yRange;
    public float floatSpeed;
    // variables for click logic
    public bool isCorrect;
    private void Start()
    {
        // this was moved to the Start method
        // otherwise the code owuld always get the component in the update
        // which is a huge performance issue
        // we only need the reference once
        // so we cache the reference
        objRenderer = GetComponent<Renderer>();
    }
    void Update()
    {
        // COLOR CHANGE LOGIC
        // gets the Renderer Component that is on the GameObject 
        // this script is attached to
        //objRenderer = GetComponent<Renderer>(); // this should be in the Start method
        // increases the timer value in normal time, not 90 times a second (frame rate)
        timer += Time.deltaTime;
        // changes the color if the interval time is met
        if (timer >= colorChangeTime)
        {
            // randomly selects a color from a color array and assigns the color
            // to the color property of the material
            int randomNum = Random.Range(0, randomColor.Length);
            newColor = randomColor[randomNum];
            objRenderer.material.color = newColor;
            // sets the timer back to 0 to reset the interval
            timer = 0;
        }
        // FLOATING LOGIC
        yPos = Mathf.PingPong(Time.time * floatSpeed, 1) * yRange;
        // sets the position value of the transform component using a Vector3 (x,y,z)
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
    }
    // SELECT LOGIC
    private void OnMouseDown()
    {
        // if the isCorrect bool is true, Destroy the game object this script is attached to
        if (isCorrect)
        {
            Destroy(this.gameObject);
        }
    }
}
