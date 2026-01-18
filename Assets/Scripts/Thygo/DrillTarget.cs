using UnityEngine;

public class DrillTarget : MonoBehaviour
{
    [SerializeField] RectTransform targetCanvas; // The canvas that holds the target
    [SerializeField] RectTransform targetImage; // The image of hte target
    
    public Vector3 targetPosition => transform.position;

    public void GenerateNewTarget()
    {
        if (targetCanvas == null || targetImage == null) return;

        // 1. Calculate the available area 
        // We subtract the circle's size so it doesn't spawn over the edge
        float maxWidth = (targetCanvas.rect.width - targetImage.rect.width) / 2;
        float maxHeight = (targetCanvas.rect.height - targetImage.rect.height) / 2;

        // 2. Pick a random spot inside those bounds
        float randomX = Random.Range(-maxWidth, maxWidth);
        float randomY = Random.Range(-maxHeight, maxHeight);

        // 3. Move the UI element
        targetImage.anchoredPosition = new Vector2(randomX, randomY);
        
        Debug.Log($"New target generated at: {randomX}, {randomY}");
    }
}
