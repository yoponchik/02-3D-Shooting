using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitManager : MonoBehaviour
{
    #region Singleton
    public static EnemyHitManager instance;

    private void Awake() {
        instance = this;
    }
    #endregion Singleton

    public GameObject imageHit;

    // Start is called before the first frame update
    void Start()
    {
        imageHit.SetActive(false);
    }

    public void Hit() {
        StopCoroutine("IEHit");
        StartCoroutine("IEHit");
    }

    IEnumerator IEHit() { 
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        imageHit.SetActive(false);
    }
}
