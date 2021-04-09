using UnityEngine;

public class DisableAfter : MonoBehaviour
{
    private float timer = 0;
    public float delay = 0.7f;

    private void OnEnable()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= delay)
            gameObject.SetActive(false);
    }
}
