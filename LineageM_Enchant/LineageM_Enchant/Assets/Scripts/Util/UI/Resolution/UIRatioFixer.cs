using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIRatioFixer : MonoBehaviour
{
    [SerializeField]
    private float allowedError = 0.0f;
    
    private void Start()
    {
        useGUILayout = false;
        RectTransform rectTransform = transform as RectTransform;
        CanvasScaler scaler = GetComponentInParent<CanvasScaler>();
        if (scaler == null)
        {
            Debug.LogError("Could not find a CanvasScaler component in parent.");
            return;
        }
        Vector2 referenceResolution = scaler.referenceResolution;
        float wph1 = referenceResolution.x / referenceResolution.y;
        float wph2 = (float)Screen.width / Screen.height;
        if (Mathf.Abs(wph1 - wph2) > allowedError)
        {
            Vector3 scale = rectTransform.localScale;
            scale.x *= wph2 / wph1;
            rectTransform.localScale = scale;
        }
    }

#if UNITY_EDITOR
    private void Reset()
    {
        SetSizeDeltaToReferenceResolution(transform);
    }

    public static void SetSizeDeltaToReferenceResolution(Transform transform_)
    {
        RectTransform rectTransform = transform_ as RectTransform;
        CanvasScaler scaler = transform_.GetComponentInParent<CanvasScaler>();
        if (scaler == null)
        {
            Debug.LogError("Could not find a CanvasScaler component in parent.");
            return;
        }
        rectTransform.sizeDelta = scaler.referenceResolution;
    }
#endif
}
