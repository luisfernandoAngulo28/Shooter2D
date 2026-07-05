using UnityEngine;
 
public class EnemigoIA : MonoBehaviour
{
    public float velocidad = 2f;
    public float distanciaDeteccion = 8f;   // a partir de aqui persigue
    public int danoContacto = 1;
    public float cadenciaDano = 1f;          // cada cuanto dana al tocar
 
    private Transform jugador;
    private SpriteRenderer sr;
    private float proximoDano = 0f;
 
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        GameObject j = GameObject.FindGameObjectWithTag("Jugador");
        if (j != null) jugador = j.transform;
    }
 
    void Update()
    {
        if (jugador == null) return;
 
        float distancia = Vector2.Distance(transform.position, jugador.position);
        if (distancia <= distanciaDeteccion)
        {
            float dir = (jugador.position.x > transform.position.x) ? 1f : -1f;
            transform.position += new Vector3(dir * velocidad * Time.deltaTime, 0, 0);
            sr.flipX = dir > 0;   // mira hacia el jugador
        }
    }
 
    // Dana al jugador mientras lo toca
    void OnCollisionStay2D(Collision2D otro)
    {
        if (otro.gameObject.CompareTag("Jugador") && Time.time >= proximoDano)
        {
            Vida v = otro.gameObject.GetComponent<Vida>();
            if (v != null) v.RecibirDaño(danoContacto);
            proximoDano = Time.time + cadenciaDano;
        }
    }
}

