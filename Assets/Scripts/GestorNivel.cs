using UnityEngine;

public class GestorNivel : MonoBehaviour
{
    public GameObject textoVictoria;

    public void NivelCompletado()
    {
        if (textoVictoria != null)
            textoVictoria.SetActive(true);   // muestra el cartel

        Time.timeScale = 0f;   // congela el juego
    }
}
