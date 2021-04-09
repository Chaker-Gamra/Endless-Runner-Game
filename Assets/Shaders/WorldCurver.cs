using UnityEngine;

[ExecuteInEditMode]
public class WorldCurver : MonoBehaviour
{
	private float curveStrength;
	private float curveStrength2;

	int m_CurveStrengthID;
    int m_CurveStrengthID2;

    private void OnEnable()
    {
		curveStrength = Random.Range(0, 1f) * 0.004f;
		curveStrength2 = Random.Range(-1f, 1f) * 0.003f;

		m_CurveStrengthID = Shader.PropertyToID("_CurveStrength");
        m_CurveStrengthID2 = Shader.PropertyToID("_CurveStrength2");
    }

	void Update()
	{
		Shader.SetGlobalFloat(m_CurveStrengthID, curveStrength);
		Shader.SetGlobalFloat(m_CurveStrengthID2, curveStrength2);
	}
}
