using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float _minTime = 2f;
    private float _maxTime = 5f;
    private bool _isTriggered = false;

    public void Triggered()
    {
        if (_isTriggered == false)
        {
            Invoke(nameof(Destroy), Random.Range(_minTime, _maxTime + 1));
            _isTriggered = true;
        }
    }

    private void Destroy()
    { 
        Destroy(gameObject);
    }
}
