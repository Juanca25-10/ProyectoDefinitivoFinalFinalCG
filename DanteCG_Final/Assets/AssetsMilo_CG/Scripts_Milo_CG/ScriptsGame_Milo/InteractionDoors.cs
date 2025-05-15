using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionDoors : MonoBehaviour, IInteractuable
{
    public bool doorOpen;
    public float doorOpenAngle = 90f;
    public float doorCloseAngle = 0f;
    public float smooth = 2f;

    public int indicePuerta; // Asigna manualmente 0 a 3 en el Inspector

    public static List<bool> EstadoPuertas = new List<bool>() { true, true, true, true };



    public void ActivarObjeto()
    {
        EstadoPuertas[indicePuerta] = doorOpen;
        if (doorOpen)
        {
            doorOpen = false;
            Debug.Log("Cerrando puerta");
            StartCoroutine(AbrirDespuesDeTiempo(5f));
        }
        else
        {
            doorOpen = true;
            Debug.Log("Abriendo puerta");
        }
    }

    IEnumerator AbrirDespuesDeTiempo(float segundos)
    {
        yield return new WaitForSeconds(segundos);
        doorOpen = true;
    }

    void Update()
    {
        if (doorOpen)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
        }
        else
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
        }
    }

    
}

