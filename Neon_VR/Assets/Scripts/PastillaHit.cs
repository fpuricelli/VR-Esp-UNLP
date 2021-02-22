using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PastillaHit : MonoBehaviour
{
    public GameObject explosion;

    public void PastillaVapor(){
        //gameObject.transform.localScale=new Vector3(0.4f,0.2f,0.6f);
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(gameObject); // destroy the sphere
        Destroy(expl, 5); // delete the explosion after 3 seconds
    }
}
