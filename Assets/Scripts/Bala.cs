using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 18f; // Velocidad de la bala
    public int danio = 1; // Daño que inflige la bala
    public float vidaSegundos = 3f; // Tiempo de vida de la bala en segundos
    private float dir = 1f; // Dirección de la bala (1 para derecha, -1 para izquierda)

    public void Lanzar(float direccion)
    {
        dir = direccion;
        if (dir < 0)
        {
            Vector3 escala = transform.localScale;
            escala.x = -Mathf.Abs(escala.x); // Voltea la escala en el eje X
            // Si la dirección es negativa, volteamos la bala
            transform.localScale = escala;
        }
        Destroy(gameObject, vidaSegundos); // Destruye la bala después de vidaSegundos
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, vidaSegundos); // Destruye la bala después de vidaSegundos    
    }

    // Update is called once per frame
    void Update()
    {
      transform.position += Vector3.right * dir * velocidad * Time.deltaTime; // Mueve la bala en la dirección especificada
    }
    void OnTriggerEnter2D(Collider2D otro)
    {

        
        if (otro.CompareTag("Enemigo"))
        {
            Vida vida = otro.GetComponent<Vida>();
            if (vida != null)
            {
                vida.RecibirDaño(danio);
            }
            Destroy(gameObject); // Destruye la bala al colisionar con un enemigo
            
        }else if (otro.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Destroy(gameObject); // Destruye la bala al colisionar con el suelo
        }
    }
}
