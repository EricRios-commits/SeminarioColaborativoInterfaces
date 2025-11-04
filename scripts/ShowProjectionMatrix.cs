using UnityEngine;

public class ShowProjectionMatrix : MonoBehaviour
{
    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.P)) // al pulsar 'P'
    {
        Matrix4x4 m = cam.projectionMatrix;
        string matrixString = "";
        for (int i = 0; i < 4; i++)
        {
            matrixString += $"{m[i,0]:F4}\t{m[i,1]:F4}\t{m[i,2]:F4}\t{m[i,3]:F4}\n";
        }
        Debug.Log("Matriz de proyección actual:\n" + matrixString);
    }
}
}
