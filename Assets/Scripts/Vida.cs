using UnityEngine;
using UnityEngine.SceneManagement;

public class Vida : MonoBehaviour
{
    public int vidaMaxima = 3;
    public bool esJugador = false;
    public int vidaActual;
    void Start()
    { //constructor, se ejecuta al iniciar el juego
        vidaActual = vidaMaxima;
    }

    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;
        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        if (esJugador)
        {    
            //Gameover:recargamos de nivel actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel actual
            // Lógica para reiniciar el nivel o mostrar la pantalla de Game Over
            //Debug.Log("El jugador ha muerto. Reiniciando el nivel...");
            // Aquí puedes agregar la lógica para reiniciar el nivel o mostrar la pantalla de Game Over
        }
        else
        {
            // Lógica para destruir al enemigo
            Destroy(gameObject);
        }
    }

    public int ObtenerVidaActual()
    {
        return vidaActual;
    }

    public int ObtenerVidaMaxima()
    {
        return vidaMaxima;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
