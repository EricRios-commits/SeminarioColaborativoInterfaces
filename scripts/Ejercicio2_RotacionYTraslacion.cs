using UnityEngine;

public class Ejercicio2_RotacionYTraslacion : MonoBehaviour
{
    public Vector3 traslacion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {     
        Vector3 rotacion = new Vector3(0, 30, 0);   
        Quaternion quaternionRotacion = Quaternion.Euler(rotacion);
        transform.rotation = quaternionRotacion;
        transform.Translate(traslacion, Space.Self);
        Debug.Log("La cámara se encuentra en la posición " + gameObject.transform.position);
        Debug.Log("La cámara tiene una rotación: " + transform.rotation.eulerAngles); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
