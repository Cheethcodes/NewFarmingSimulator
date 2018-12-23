/*
 * 
 * Author: Gabriel Hansley Suarez
 * Date Created: December 21, 2018
 * Source: 
 * 
 * Modified by: Gabriel Hansley Suarez
 * Date Modified: December 21, 2018
 * Last Date Modified: December 21, 2018
 * 
 * Contributors:
 * 
 * Credits: -----------
 * 
 * License: 
 * 
 * Note: Camera Movement with mouse
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    // Speed of camera movement when dragging
    float speed_horizontal = 10f;
    float speed_vertical = 20f;

    // Get Camera object
    public Camera cam;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // press and drag - movement of camera
        if (Input.GetMouseButton(0) && pInteractions.currentTool == "action-None")
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                if (cam.transform.position.x != 190f)
                    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed_horizontal, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed_vertical, 0.0f);
                else
                    transform.position -= new Vector3(0.0f, 0.0f, 0.0f);
            }
            else if (Input.GetAxis("Mouse X") < 0)
            {
                if (cam.transform.position.x != -190f)
                    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed_horizontal, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed_vertical, 0.0f);
                else
                    transform.position -= new Vector3(0.0f, 0.0f, 0.0f);
            }
        }

        // zoom - movement of camera (orthographic)
        if ((((Input.GetAxis("Mouse ScrollWheel") > 0f) || (Input.GetKey(KeyCode.KeypadPlus))) && !(cam.orthographicSize <= 4)) && pInteractions.currentTool == "action-None")
        {
            cam.orthographicSize -= 2f;
        }
        if ((((Input.GetAxis("Mouse ScrollWheel") < 0f) || (Input.GetKey(KeyCode.KeypadMinus))) && !(cam.orthographicSize >= 20)) && pInteractions.currentTool == "action-None")
            cam.orthographicSize += 2f;
    }



}
