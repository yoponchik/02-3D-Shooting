using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get User input from the movement keys
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        //make inputs into one vector to move the Player
        //Vector3 direction = Vector3.right * hori + Vector3.forward * verti;
        Vector3 direction = new Vector3(hori, 0, verti);
        direction.Normalize();                                                          //Normalize

        transform.position += direction * speed * Time.deltaTime;                       //Move the Player
    }
}
