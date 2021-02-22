using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VrGaze : MonoBehaviour
{
    public float totalTime=5;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay=10;
    private RaycastHit _hit;

    public Text objetosDist;
    public Text objetosTiempoVista;

    public GameObject paredAbre;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray=Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        
        if(Physics.Raycast(ray, out _hit,distanceOfRay)){
            objetosTiempoVista.text=":: "+gvrTimer.ToString()+" ::";
            if(_hit.transform.CompareTag("EsferaHit") && _hit.distance<=Globales.distanceOfRayToBola){
                if(gvrTimer>=totalTime){
                _hit.transform.gameObject.GetComponent<EsferaHit>().EsferaDeforme();
                gvrStatus=false;
                gvrTimer=0;
                } else {
                    gvrTimer+=Time.deltaTime;
                }
            } 
            if(_hit.transform.CompareTag("EstrellaHit") && _hit.distance<=Globales.distanceOfRayToEstrella){
                if(gvrTimer>=totalTime){
                _hit.transform.gameObject.GetComponent<EstrellaHit>().EstrellaExplota();
                gvrStatus=false;
                gvrTimer=0;
                } else {
                    gvrTimer+=Time.deltaTime;
                }
            } 
            if(_hit.transform.CompareTag("PastillaHit") && _hit.distance<=Globales.distanceOfRayToPastilla){
                if(gvrTimer>=totalTime){
                _hit.transform.gameObject.GetComponent<PastillaHit>().PastillaVapor();
                gvrStatus=false;
                gvrTimer=0;
                paredAbre.SetActive(false);
                paredAbre.GetComponent<MeshCollider>().enabled = false;
                } else {
                    gvrTimer+=Time.deltaTime;
                }
            } 
            objetosDist.text=">> "+_hit.distance.ToString()+" <<";
        }
    }
}
