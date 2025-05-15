using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_Paraiso : MonoBehaviour
{
    private NavMeshAgent agente;
    private Transform jugador;

    // Posición de respawn del jugador (puede ser pública o asignada desde GameManager)
    public Vector3 puntoRespawn;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            jugador = playerObj.transform;

            // Guardamos la posición inicial como punto de respawn por defecto
            puntoRespawn = jugador.position;
        }
    }

    void Update()
    {
        if (jugador != null)
        {
            agente.SetDestination(jugador.position);
        }
    }

    // Detectar colisión con el jugador
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Teletransporta al jugador al punto de respawn
            jugador.position = puntoRespawn;

            // También puedes resetear otros estados aquí si es necesario
            Debug.Log("¡El enemigo tocó al jugador! Reiniciando posición.");
        }
    }
}
