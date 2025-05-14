using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public string EscenaCambio;

    public void CambiarEscena()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.CambiarEscena(EscenaCambio);
        }
    }
}
