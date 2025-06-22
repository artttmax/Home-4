using UnityEngine;

public class Triggerer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ColorChanger colorChanger))
        {
            if (other.gameObject.TryGetComponent(out Destroyer destroyer))
            {
                colorChanger.ChangeColor();
                destroyer.Triggered();
            }
        }
    }
}
