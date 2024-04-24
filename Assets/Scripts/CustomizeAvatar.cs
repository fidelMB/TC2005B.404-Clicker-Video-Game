using UnityEngine;
using UnityEngine.UI;

public class CustomizeAvatar : MonoBehaviour
{
    public GameObject targetObject; // The object with the image to change (e.g., the current hat on the avatar)
    public GameObject sourceObject; // The object with the image to copy (e.g., the selected hat option)

    public void ApplyImageToTarget()
    {
        // Get the Image components from both objects
        Image targetImage = targetObject.GetComponent<Image>();
        Image sourceImage = sourceObject.GetComponent<Image>();

        if (targetImage != null && sourceImage != null)
        {
            // Set the target image to the source image
            targetImage.sprite = sourceImage.sprite;
        }
        else
        {
            Debug.LogError("Image component missing on one of the objects.");
        }
    }
}


