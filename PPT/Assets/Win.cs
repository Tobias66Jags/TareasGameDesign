using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
 public string P1, P2;

    public int DeterminarGanador(int decisionJugador1, int decisionJugador2)
    {
        if (decisionJugador1 == decisionJugador2)
        {
            return 0; // Empate
        }
        else if ((decisionJugador1 == 1 && decisionJugador2 == 3) ||
                 (decisionJugador1 == 2 && decisionJugador2 == 1) ||
                 (decisionJugador1 == 3 && decisionJugador2 == 2))
        {
            return 1; // Jugador 1 gana
        }
        else if ((decisionJugador1 == 3 && decisionJugador2 == 1) ||
                 (decisionJugador1 == 1 && decisionJugador2 == 2) ||
                 (decisionJugador1 == 2 && decisionJugador2 == 3))
        {
            return 2; // Jugador 2 gana
        }
        else if (decisionJugador1 == 0 && (decisionJugador2 == 1 || decisionJugador2 == 2 || decisionJugador2 == 3))
        {
            return 2; // Jugador 2 gana si jugador 1 no elige nada
        }
        else if (decisionJugador2 == 0 && (decisionJugador1 == 1 || decisionJugador1 == 2 || decisionJugador1 == 3))
        {
            return 1; // Jugador 1 gana si jugador 2 no elige nada
        }
        else
        {
            return 0; // Ningún jugador elige una opción válida
        }
    }

}
