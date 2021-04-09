using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine;

public class Randomness : MonoBehaviour
{
    private Volume volume;
    private ColorAdjustments colorAdjustments;
    public float[] randomHueShitf;

    void Start()
    {
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out colorAdjustments);
        colorAdjustments.hueShift.value = randomHueShitf[Random.Range(0, randomHueShitf.Length)];
    }
}
