using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //bullet effect
    Camera cam;
    public GameObject bulletImpact;
    ParticleSystem ps;



    void Start()
    {
        cam = Camera.main;
        ps = bulletImpact.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) { 
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);               //Create a ray from the camera pointing out
            RaycastHit hitInfo;                                                             //Create a Raycast variable

            //int layer = 1 << 8;
            int layer = 1 << LayerMask.NameToLayer("Player");

            if (Physics.Raycast(ray, out hitInfo, float.MaxValue, ~layer)) { 
                bulletImpact.transform.position = hitInfo.point;                            //place the particle VFX at the hitpoint
                bulletImpact.transform.forward = hitInfo.normal;
                ps.Stop();
                ps.Play();                                                                  //because it is a particle system effect, we need to give it a play command




                if (hitInfo.transform.gameObject.CompareTag("Enemy")) {             //if the hit GO is Enemy
                    Enemy enemy = hitInfo.transform.GetComponent<Enemy>();          //Get the component of the GO Enemy
                    if (enemy != null) {
                        enemy.ShotByGun();                                          //tell enemy it was shot
                    }
                    else {
                        Debug.Log("Couldn't find Enemy Script in GO Enemy");
                    }

                    //Destroy(hitInfo.transform.gameObject);
                }
            }
        }
    
    }

}
