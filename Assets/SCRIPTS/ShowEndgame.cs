using UnityEngine;

public class ShowEndgame : MonoBehaviour
{
    [SerializeField] private MultiplayerScriptableObject multiplayer;
    private TMPro.TextMeshProUGUI text;
    private void Start()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        if (multiplayer.isMultiplayer)
        {
            if(DatosPartida.player1Points > DatosPartida.player2Points)
            {
                text.text = "Congratulations\nPlayer 1 win with:\n$" + DatosPartida.player1Points;
            }
            else if (DatosPartida.player1Points < DatosPartida.player2Points)
            {
                text.text = "Congratulations\nPlayer 2 win with:\n$" + DatosPartida.player2Points;
            }
            else
            {
                text.text = "Congratulations\nBoth player win with:\n$" + DatosPartida.player1Points;
            }
        }
        else
        {
            text.text = "Congratulations\nYour recollected:\n$" + DatosPartida.player1Points;
        }
    }
}