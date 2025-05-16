using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum GameState
{
    PreInicio,
    JugandoTutorial,
    Jugando,
    FinJuego
}
public class GameController_ParaisoOscuro : MonoBehaviour
{
    public GameState estadoActual = GameState.PreInicio;
    EnemyController_Paraiso enemigoController;
    InteractionDoors InteraccionPuerta;

    private GameManager gm;
    public int objetosRecolectadosEscena = 0;
    public int objetosNecesariosEscena = 4;
    public TextMeshProUGUI textoPuntaje;

    public int puertasAbiertas= 0;
    public int puertasNecesarias2daParte = 8;
    public int puertasNecesariasTerminar = 16;

    void Start()
    {
        estadoActual = GameState.PreInicio;
        gm = GameManager.Instance;
        enemigoController = FindObjectOfType<EnemyController_Paraiso>();
    }

    public void EstadoJugandoTutorial()
    {
        estadoActual = GameState.JugandoTutorial;
        enemigoController.IniciarRutinaEnemigo1();

        Debug.Log("Estado: Jugando Tutorial");
    }

    public void EstadoJugando()
    {
        estadoActual = GameState.Jugando;
        enemigoController.IniciarRutinaEnemigo2();
        Debug.Log("Estado: Jugando");
    }

    public void EstadoFinJuego()
    {
        estadoActual = GameState.FinJuego;
        enemigoController.DetenerRutinaEnemigo1();
        enemigoController.DetenerRutinaEnemigo2();

        InteractionDoors.CerrarTodasLasPuertas();

        Debug.Log("Estado: FinJuego");
    }

    public void PuertaCerradaCorrectamente()
    {
        if(estadoActual == GameState.JugandoTutorial || estadoActual == GameState.Jugando)
        {
            puertasAbiertas++;
            gm.SumarObjeto();
            if (puertasAbiertas == puertasNecesarias2daParte)
            {
                estadoActual = GameState.Jugando;
                //Metodo que activa esqueletosEnemy
                Debug.Log("Estado: JugandoEsqueletos");
            }
            if (puertasAbiertas == puertasNecesariasTerminar)
            {
                estadoActual = GameState.FinJuego;
                enemigoController.DetenerRutinaEnemigo1(); //Detiene la rutina del enemigoPuertas
                Debug.Log("Estado: FinJuego");
            }
        }
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
