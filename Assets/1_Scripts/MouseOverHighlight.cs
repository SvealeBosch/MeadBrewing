using UnityEngine;

public class MouseOverHighlight : MonoBehaviour
{
    [SerializeField] private Material highlightMaterial = null;
    
    private Material[] defaultMaterials;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        defaultMaterials = meshRenderer.materials;
    }

    private void OnMouseEnter()
    {
        var materials = meshRenderer.materials;
        
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = highlightMaterial;
        }

        meshRenderer.materials = materials;
    }

    private void OnMouseExit()
    {
        meshRenderer.materials = defaultMaterials;
    }
}