using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MostrarTextoSecuencia1 : MonoBehaviour
{
    public TextMeshProUGUI[] textosOrdenados;  // Aquí asignas manualmente los textos en el orden deseado
    public float tiempoEntreTextos = 1f;

    void Start()
    {
        foreach (var texto in textosOrdenados)
        {
            texto.gameObject.SetActive(false);
        }
        StartCoroutine(MostrarTextos());
    }

    IEnumerator MostrarTextos()
    {
        foreach (var texto in textosOrdenados)
        {
            texto.gameObject.SetActive(true);
            yield return new WaitForSeconds(tiempoEntreTextos);
        }
    }
}
