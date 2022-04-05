using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    Rigidbody rb;
    public float force = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * force;
    }

    private void OnCollisionEnter(Collision other) {

        int layer = 1 << LayerMask.NameToLayer("Enemy");

        Collider[] cols = Physics.OverlapSphere(other.contacts[0].point, 1.5f, layer);
        if (cols.Length > 0) {                                                              //if there is anything inside the cols array
            for (int i = 0; i < cols.Length; i++) {
                cols[i].gameObject.GetComponent<Enemy>().HitByBomb();
            }
        }
        Destroy(gameObject);                                                                //Destroy GO Bomb
    }

}
