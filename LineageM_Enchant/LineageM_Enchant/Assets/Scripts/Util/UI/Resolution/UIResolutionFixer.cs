using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIResolutionFixer : MonoBehaviour
{
	private void Start()
    {
        RectTransform rectTransform = transform as RectTransform;
        CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
        if (scaler == null)
        {
            Debug.LogError("Could not find a CanvasScaler component in parent.");
            return;
        }
        Vector2 size = rectTransform.sizeDelta;
        Vector2 referenceResolution = scaler.referenceResolution;
        float standardRatio = referenceResolution.x / referenceResolution.y;
        float screenRatio = (float)Screen.width / Screen.height;
        size.x *= screenRatio / standardRatio;
        rectTransform.sizeDelta = size;
    }

#if UNITY_EDITOR
    private void Reset()
    {
        UIRatioFixer.SetSizeDeltaToReferenceResolution(transform);
    }
#endif
}
