using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float rotationX, rotationY;
    float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get user input from mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        //store and accumulate rotation values
        rotationX += mouseY * rotationSpeed * Time.deltaTime;
        rotationY += mouseX * rotationSpeed * Time.deltaTime;

        //Constrain the rotationX angle (vertical mouse movement)
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        //Rotate the Camera
        transform.eulerAngles = new Vector3(-rotationX,rotationY, 0);
    }

}
