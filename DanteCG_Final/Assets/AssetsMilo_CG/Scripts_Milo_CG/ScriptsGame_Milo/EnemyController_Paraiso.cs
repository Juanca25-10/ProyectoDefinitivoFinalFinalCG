using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController_Paraiso : MonoBehaviour
{
    private NavMeshAgent agente;
    private Transform jugador;

    // Posici�n de respawn del jugador (puede ser p�blica o asignada desde GameManager)
    public Vector3 puntoRespawn;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj != null)
        {
            jugador = playerObj.transform;
            Debug.Log("Jugador encontrado: " + jugador.name);

            // Guardamos la posici�n inicial como punto de respawn por defecto
            puntoRespawn = jugador.position;
            Debug.Log("Punto de respawn inicial: " + puntoRespawn);
        }
    }

    void Update()
    {
        if (jugador != null)
        {
            agente.SetDestination(jugador.position);
        }
    }

    // Detectar colisi�n con el jugador
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CharacterController cc = jugador.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            jugador.position = puntoRespawn;

            if (cc != null) cc.enabled = true;

            Debug.Log("�Enemy toc� al jugador con CharacterController! Teleport.");
        }
    }
}
