using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasEnemy : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
        //mira hacia la c�mara de la escena que tenga la etiqueta "MainCamera"
        transform.LookAt(Camera.main.transform.position);

    }
}
