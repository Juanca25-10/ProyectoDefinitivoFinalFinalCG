using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController_ParaisoOscuro : MonoBehaviour
{
    private GameManager gm;
    public int objetosRecolectadosEscena = 0;
    public int objetosNecesariosEscena = 4;
    public TextMeshProUGUI textoPuntaje;

    void Start()
    {
        gm = GameManager.Instance;
    }

    public void ObjetoRecolectado()
    {
        if (objetosRecolectadosEscena < objetosNecesariosEscena) if (gm != null)
        {
            objetosRecolectadosEscena++;
            textoPuntaje.text = objetosRecolectadosEscena.ToString();
            gm.SumarObjeto();
        }
        
    }
}
