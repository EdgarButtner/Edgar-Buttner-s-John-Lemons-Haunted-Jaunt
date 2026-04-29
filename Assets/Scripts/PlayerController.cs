using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isVisible = true;

    Renderer m_Renderer;
    Material[] m_NormalMaterials;
    Material m_InvisibleMaterial;

    void Start()
    {
        m_Renderer = transform.Find("JohnLemon").GetComponent<Renderer>();
        m_NormalMaterials = m_Renderer.materials;
        m_InvisibleMaterial = m_Renderer.materials[2];
    }

    public void SetInvisible(float duration)
    {
        StopAllCoroutines(); 
        StartCoroutine(InvisibilityCoroutine(duration));
    }

    IEnumerator InvisibilityCoroutine(float duration)
    {
        Material[] invisible = new Material[m_NormalMaterials.Length];
        for (int i = 0; i < invisible.Length; i++)
            invisible[i] = m_InvisibleMaterial;
        m_Renderer.materials = invisible;
        isVisible = false;

        yield return new WaitForSeconds(duration);

        m_Renderer.materials = m_NormalMaterials;
        isVisible = true;
    }
}