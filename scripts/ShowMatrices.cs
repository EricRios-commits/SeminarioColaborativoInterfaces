using UnityEngine;

public class ShowMatrices : MonoBehaviour
{
    public Camera cam;
    public Transform target;

    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // --- MATRIZ DE MODELO ---
            Matrix4x4 model = target.localToWorldMatrix;
            Debug.Log("Model Matrix:\n" + MatrixToString(model));

            // --- MATRIZ DE VISTA ---
            Matrix4x4 view = cam.worldToCameraMatrix;
            Debug.Log("View Matrix:\n" + MatrixToString(view));

        }
    }

    string MatrixToString(Matrix4x4 m)
    {
        string s = "";
        for (int i = 0; i < 4; i++)
            s += $"{m[i,0]:F3}  {m[i,1]:F3}  {m[i,2]:F3}  {m[i,3]:F3}\n";
        return s;
    }
}
