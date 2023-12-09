using UnityEngine;
using UnityEngine.UI;

public class CollisionStartup : MonoBehaviour
{
    Image image;

    void Awake()
    {
        image = GetComponent<Image>();
        if (image != null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
        }
    }
}
