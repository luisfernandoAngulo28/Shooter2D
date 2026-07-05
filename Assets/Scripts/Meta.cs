using UnityEngine;

public class Meta : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        Debug.Log("Meta: trigger tocado por " + otro.gameObject.name + " con tag " + otro.gameObject.tag);
        if (otro.CompareTag("Jugador"))
        {
            // Unity 6.5: FindFirstObjectByType (FindObjectOfType quedo obsoleto)
            GestorNivel gestor = FindFirstObjectByType<GestorNivel>();
            Debug.Log("Meta: gestor encontrado = " + (gestor != null));
            if (gestor != null) gestor.NivelCompletado();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
