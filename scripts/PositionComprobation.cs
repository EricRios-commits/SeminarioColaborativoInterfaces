using UnityEngine;

public class PositionComprobation : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(3f, 1f, 1f);
        transform.rotation = Quaternion.Euler(45f, 0f, 45f);

        Debug.Log("Origen mundial: " + transform.position);
        Debug.Log("Eje X local en mundo (right): " + transform.right);
        Debug.Log("Eje Y local en mundo (up): " + transform.up);
        Debug.Log("Eje Z local en mundo (forward): " + transform.forward);
    }
}
