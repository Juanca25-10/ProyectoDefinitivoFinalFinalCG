using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEsqueletos : MonoBehaviour, IInteractuable

{
    //AudioSource audioSource;
    //public AudioClip sonidoEsqueleto;
    EnemyController_Paraiso enemigoControllerPuertas;

    private Coroutine rutinaAparicion;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        this.gameObject.SetActive(false);
        enemigoControllerPuertas = FindObjectOfType<EnemyController_Paraiso>();
        
    }

    void Update()
    {
        // Si el jugador ha perdido, detiene la rutina de aparición
        if (enemigoControllerPuertas.JugadorPerdio)
        {
            if (rutinaAparicion != null)
            {
                StopCoroutine(rutinaAparicion);
                rutinaAparicion = null;
                this.gameObject.SetActive(false);
            }
        }
    }

    public void IniciarEnemigoEsqueletos()
    {
        // Inicia la corutina que lo activa cada cierto tiempo
        rutinaAparicion = StartCoroutine(AparicionAleatoria());
    }

    IEnumerator AparicionAleatoria()
    {
        while (true)
        {
            // Espera entre 5 y 10 segundos
            float tiempoEspera = Random.Range(5f, 10f);
            yield return new WaitForSeconds(tiempoEspera);

            // Activa el esqueleto
            ActivarEsqueleto();
        }
    }

    public void ActivarEsqueleto()
    {
        if (!gameObject.activeSelf)
        {
            this.gameObject.SetActive(true);
            //audioSource.PlayOneShot(sonidoEsqueleto);
        }
    }

    public void ActivarObjeto()
    {
        this.gameObject.SetActive(false);
    }
}
