using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Camera))]
public class FloatingOrigin : MonoBehaviour
{
    public float threshold = 100.0f;

    void FixedUpdate()
    {
        Vector3 cameraPosition = gameObject.transform.position;
        cameraPosition.y = 0f;

        if (cameraPosition.magnitude + 10 >= threshold)
        {
            cameraPosition.z += 10;
            foreach (GameObject g in SceneManager.GetActiveScene().GetRootGameObjects())
            {
                if (g.layer == 9)
                    g.transform.position -= cameraPosition;
            }

            FindObjectOfType<TileManager>().zSpawn = 60;
        }
        
    }
}