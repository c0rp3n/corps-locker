using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private bool ButtonLeftPressed = false;
    private bool ButtonRightPressed = false;
    private bool ButtonUpPressed = false;
    private bool ButtonDownPressed = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetAxis("Horizontal") > 0.0f)
        {
            if (ButtonRightPressed == false)
            {
                transform.position += new Vector3(1, 0, 0);
            }
            ButtonRightPressed = true;
        }
        else
        {
            ButtonRightPressed = false;
        }

        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            if (ButtonLeftPressed == false)
            {
                transform.position += new Vector3(-1, 0, 0);
            }
            ButtonLeftPressed = true;
        }
        else
        {
            ButtonLeftPressed = false;
        }

        if (Input.GetAxis("Vertical") > 0.0f)
        {
            if (ButtonUpPressed == false)
            {
                transform.position += new Vector3(0, 0, 1);
            }
            ButtonUpPressed = true;
        }
        else
        {
            ButtonUpPressed = false;
        }

        if (Input.GetAxis("Vertical") < 0.0f)
        {
            if (ButtonDownPressed == false)
            {
                transform.position += new Vector3(0, 0, -1);
            }
            ButtonDownPressed = true;
        }
        else
        {
            ButtonDownPressed = false;
        }
    }
}
