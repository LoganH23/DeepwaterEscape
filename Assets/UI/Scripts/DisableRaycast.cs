using UnityEngine;
using UnityEngine.UI;

public class DisableRaycast : MonoBehaviour
{
    void Start()
    {
        // Disable Raycast Target on Image
        GetComponent<Image>().raycastTarget = false;

        // If using Canvas Group
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
