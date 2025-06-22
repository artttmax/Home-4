using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private Color DefaultColor;

    private Renderer _cubeRenderer;

    private void Awake()
    {
        _cubeRenderer = GetComponent<Renderer>();
        DefaultColor = _cubeRenderer.material.color;
    }

    public void BackToInitialColor()
    {
        _cubeRenderer.material.color = DefaultColor;
    }

    public void ChangeColor()
    {
        _cubeRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
