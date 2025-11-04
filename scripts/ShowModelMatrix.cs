using UnityEngine;

public class ShowModelMatrix : MonoBehaviour
{
    void Start()
    {
        // Aplicamos una rotación de 45 grados en el eje Y al inicio
        transform.Rotate(0f, 45f, 0f, Space.Self);

        // Obtenemos la matriz de cambio al sistema de referencia mundial
        Matrix4x4 modelMatrix = transform.localToWorldMatrix;

        // Mostramos la matriz en consola
        Debug.Log("Matriz de cambio al sistema de referencias mundial (Model Matrix):\n" + MatrixToString(modelMatrix));
    }

    string MatrixToString(Matrix4x4 m)
    {
        string s = "";
        for (int i = 0; i < 4; i++)
            s += $"{m[i,0]:F2}{m[i,1]:F2}  {m[i,2]:F2}  {m[i,3]:F2}\n";
        return s;
    }
}
