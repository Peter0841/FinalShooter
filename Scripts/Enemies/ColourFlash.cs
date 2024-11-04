using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourFlash : MonoBehaviour
{
    private Renderer objectRenderer;
    private Color originalColor;     

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) 
        {
            StartCoroutine(changeColour());
        }
    }

    private IEnumerator changeColour()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = Color.red;
        }

        yield return new WaitForSeconds(0.1f);

        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
