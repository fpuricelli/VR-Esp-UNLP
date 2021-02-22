using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstrellaHit : MonoBehaviour
{
    public Text estrellasText;

    public void EstrellaExplota(){
        
        Destroy(gameObject); // destroy
        Globales.cantidadEstrellas++;
        estrellasText.text = "Estrellas: "+Globales.cantidadEstrellas.ToString();
    }
}

