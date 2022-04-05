using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombLauncher : MonoBehaviour
{
    public GameObject bombFactory;
    public Transform firePosition;
    public float force = 15;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G)) {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePosition.position;
            bomb.transform.forward = firePosition.forward;
            bomb.GetComponent<Bomb>().force = force;
        }
    }
}
