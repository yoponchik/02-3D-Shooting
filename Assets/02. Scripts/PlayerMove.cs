using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Move
    public float speed = 5;

    //Jump
    public float yVelocity = 0;
    public int maxJumpCount = 2;
    int jumpCount = 0;
    [SerializeField] float jumpPower = 10;
    [SerializeField] float gravity = -9.81f;

    //Character Controller
    CharacterController cc;

    private void Start() {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move() {
        //Get User input from the movement keys
        float hori = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        #region Transform Movement
        /*        
                //make inputs into one vector to move the Player
                //Vector3 direction = Vector3.right * hori + Vector3.forward * verti;
                Vector3 direction = new Vector3(hori, 0, verti);
                direction.Normalize();                                                          //Normalize

                transform.position += direction * speed * Time.deltaTime;                       //Move the Player*/
        #endregion Transform Movement

        //velocity in the air
        if (cc.isGrounded) {        //When on the ground
            jumpCount = 0;
            yVelocity = 0;
        }
        else {                      //When in the air
            yVelocity += gravity * Time.deltaTime;
        }

        //Character Controller Movement
        Vector3 direction = new Vector3 (hori, 0, verti);
        direction = Camera.main.transform.TransformDirection(direction);            //Move in the direction the camera is pointing in
        direction.Normalize();
        Vector3 velocity = direction * speed;
        velocity.y = yVelocity;                                         //set y component of velocity
        cc.Move(velocity * Time.deltaTime);                             //move
    }

    void Jump() {
        if (jumpCount < maxJumpCount && Input.GetButtonDown("Jump")) {
            yVelocity = jumpPower;
            jumpCount++;
        }
    }
}
