using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    public Transform objetivo;       // el jugador
    public float suavizado = 5f;
    public Vector3 desfase = new Vector3(0, 1, -10);  // Z=-10 es clave en 2D
 
    void LateUpdate()
    {
        if (objetivo == null) return;
        Vector3 destino = objetivo.position + desfase;
        transform.position = Vector3.Lerp(
                                transform.position, 
                                destino, 
                                suavizado * Time.deltaTime
                            );
    }

}
