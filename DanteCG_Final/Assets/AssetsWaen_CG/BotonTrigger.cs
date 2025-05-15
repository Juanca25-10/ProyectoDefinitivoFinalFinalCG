using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonTrigger : MonoBehaviour
{
    public NewBehaviourScript puertaControlador; // Referencia al script del Empty

    public void Interactuar()
    {
        if (puertaControlador != null)
        {
            puertaControlador.TogglePuerta(); // Llama la función real
        }
    }



}
