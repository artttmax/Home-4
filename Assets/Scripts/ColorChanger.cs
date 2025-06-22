using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class ColorChanger : MonoBehaviour
{
    private bool isColorChanged = false;

    public void ChangeColor()
    {
        if (isColorChanged == false)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(0, 1, 0);
            isColorChanged = true;
        }
    }
}
