using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_Paraiso : MonoBehaviour
{
    private GameController_ParaisoOscuro gameC;
    public GameObject[] puntosDeAparicion; // Asigna aquí tus 4 esferas
    public float tiempoParaReaccionar = 15f;
    public AudioSource audioSource;
    public AudioClip[] sonidosPuerta; // Un sonido distinto por puerta

    private bool jugadorPerdio = false;
    private int indiceActual = -1;
    private Coroutine rutinaEnemigo;

    void Start()
    {
        for (int i = 0; i < puntosDeAparicion.Length; i++)
        {
            puntosDeAparicion[i].SetActive(false);
        }

        gameC = FindObjectOfType<GameController_ParaisoOscuro>();
    }

    public void IniciarRutinaEnemigo1()
    {
        rutinaEnemigo = StartCoroutine(AparicionEnemigoPuertas());
        Debug.Log("Iniciando rutina enemigo 1");
    }

    public void IniciarRutinaEnemigo2()
    {
        // Aquí puedes iniciar otra rutina si es necesario
        Debug.Log("Iniciando rutina enemigo 2");
    }

    public void DetenerRutinaEnemigo2()
    {
        // Aquí puedes detener la rutina del enemigo 2 si es necesario
        Debug.Log("Deteniendo rutina enemigo 2");
    }

    public void DetenerRutinaEnemigo1()
    {
        if (rutinaEnemigo != null)
            StopCoroutine(rutinaEnemigo);
        Debug.Log("Deteniendo rutina enemigo 1");
    }

    IEnumerator AparicionEnemigoPuertas()
    {
        while (!jugadorPerdio)
        {
            // Desactiva todas las esferas antes de activar la nueva
            for (int i = 0; i < puntosDeAparicion.Length; i++)
            {
                puntosDeAparicion[i].SetActive(false);
            }

            // Elegir punto aleatorio y mover al enemigo
            indiceActual = Random.Range(0, puntosDeAparicion.Length);
            Transform punto = puntosDeAparicion[indiceActual].transform;
            puntosDeAparicion[indiceActual].SetActive(true); // Activar la nueva esfera
            transform.position = punto.position;

            // Sonido
            if (audioSource && sonidosPuerta.Length > indiceActual)
                AudioSource.PlayClipAtPoint(sonidosPuerta[indiceActual], punto.position);

            Debug.Log("¡Enemigo en puerta: " + indiceActual + "!");

            // Esperar por reacción del jugador
            float tiempo = 0f;
            while (tiempo < tiempoParaReaccionar)
            {
                if (InteractionDoors.EstadoPuertas[indiceActual] == false)
                {
                    Debug.Log("Puerta cerrada " + indiceActual + " a tiempo.");
                    break; // No necesitas desactivar aquí, ya se desactivan al inicio del loop

                    //gameC.PuertaCerradaCorrectamente();
                }

                tiempo += Time.deltaTime;
                yield return null;
            }

            if (InteractionDoors.EstadoPuertas[indiceActual] == true)
            {
                jugadorPerdio = true;
                Debug.Log("¡PERDISTE!");
                // Puedes llamar aquí a GameOver
                break;
            }

            yield return new WaitForSeconds(2f);
        }

        // Asegúrate de desactivar todas al terminar
        for (int i = 0; i < puntosDeAparicion.Length; i++)
        {
            puntosDeAparicion[i].SetActive(false);
        }
    }
}
