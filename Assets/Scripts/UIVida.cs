using UnityEngine;
using TMPro;

public class UIVida : MonoBehaviour
{
    public Vida vidaJugador;     // arrastra el Jugador aqui
    private TMP_Text texto;

    void Start()
    {
        texto = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (vidaJugador != null)
            texto.text = "Vida: " + vidaJugador.ObtenerVidaActual();
    }
}
