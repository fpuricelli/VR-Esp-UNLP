using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class VrGazeInit : MonoBehaviour
{
    public float totalTime=5;
    bool gvrStatus;
    float gvrTimer;

    public int distanceOfRay=10;
    private RaycastHit _hit;

    public Text expresionArmada;
    public AudioClip audioPoint;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray=Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0f));
        
        if(Physics.Raycast(ray, out _hit,distanceOfRay)){
            if(gvrTimer>=totalTime){
                if(_hit.transform.CompareTag("BotonIniciar")){
                    Debug.Log(">>INIT");
                    SceneManager.LoadScene("EscenaPrincipal");
                }
                if(_hit.transform.CompareTag("EsferaHit")){
                    expresionArmada.text=expresionArmada.text+" BOLA ";
                }
                if(_hit.transform.CompareTag("EstrellaHit")){
                    expresionArmada.text=expresionArmada.text+" ESTRELLA ";
                }
                if(_hit.transform.CompareTag("Mayor")){
                    expresionArmada.text=expresionArmada.text+" > ";
                }
                if(_hit.transform.CompareTag("Menor")){
                    expresionArmada.text=expresionArmada.text+" < ";
                }
                if(_hit.transform.CompareTag("Igual")){
                    expresionArmada.text=expresionArmada.text+" = ";
                }
                if(_hit.transform.CompareTag("OpY")){
                    expresionArmada.text=expresionArmada.text+" Y";
                }
                if(_hit.transform.CompareTag("OpO")){
                    expresionArmada.text=expresionArmada.text+" O";
                }
                if(_hit.transform.CompareTag("OpNo")){
                    expresionArmada.text=expresionArmada.text+" No";
                }
                if(_hit.transform.CompareTag("parentesis1")){
                    expresionArmada.text=expresionArmada.text+"(";
                }
                if(_hit.transform.CompareTag("parentesis2")){
                    expresionArmada.text=expresionArmada.text+")";
                }
                if(_hit.transform.CompareTag("num4")){
                    expresionArmada.text=expresionArmada.text+"4";
                }
                if(_hit.transform.CompareTag("num2")){
                    expresionArmada.text=expresionArmada.text+"2";
                }
                gvrStatus=false;
                gvrTimer=0;
                audioSource.PlayOneShot(audioPoint, 0.7F);
                } else {
                    gvrTimer+=Time.deltaTime;
                }
        }
    }
}
