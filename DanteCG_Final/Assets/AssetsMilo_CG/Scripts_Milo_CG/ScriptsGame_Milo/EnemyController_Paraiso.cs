using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_Paraiso : MonoBehaviour
{
    public Transform[] puntosDeAparicion; // Asigna aquí tus 4 esferas
    public float tiempoParaReaccionar = 10f;
    public AudioSource audioSource;
    public AudioClip[] sonidosPuerta; // Un sonido distinto por puerta

    private bool jugadorPerdio = false;
    private int indiceActual = -1;
    private Coroutine rutinaEnemigo;

    void Start()
    {
        IniciarRutina();
    }

    public void IniciarRutina()
    {
        rutinaEnemigo = StartCoroutine(AparicionEnemigo());
    }

    public void DetenerRutina()
    {
        if (rutinaEnemigo != null)
            StopCoroutine(rutinaEnemigo);
    }

    IEnumerator AparicionEnemigo()
    {
        while (!jugadorPerdio)
        {
            Debug.Log("Cambiando de posicion enemy");
            indiceActual = Random.Range(0, puntosDeAparicion.Length);
            Transform punto = puntosDeAparicion[indiceActual];
            transform.position = punto.position;

            // Sonido de aviso
            if (audioSource && sonidosPuerta.Length > indiceActual)
                audioSource.PlayOneShot(sonidosPuerta[indiceActual]);

            Debug.Log("¡Enemigo en puerta: " + indiceActual + "!");

            // Esperar a que se cierre la puerta
            float tiempo = 0f;
            while (tiempo < tiempoParaReaccionar)
            {
                if (InteractionDoors.EstadoPuertas[indiceActual] == false) // Puerta cerrada
                {
                    Debug.Log("Puerta cerrada a tiempo.");
                    break;
                }

                tiempo += Time.deltaTime;
                yield return null;
            }

            // Si no se cerró a tiempo
            if (InteractionDoors.EstadoPuertas[indiceActual] == true)
            {
                jugadorPerdio = true;
                Debug.Log("¡PERDISTE!");
                // Aquí puedes activar un GameOver u otro evento
                break;
            }

            // Esperar un poco antes de reaparecer
            yield return new WaitForSeconds(2f);
        }
    }
}
