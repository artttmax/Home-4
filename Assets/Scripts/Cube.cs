using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    public event Action<Cube> Release;

    private Coroutine _coroutine;
    private ColorChanger _cubeColor;

    private float _minLifeTime = 2f;
    private float _maxLifeTime = 5f;

    private void Awake()
    {
        _cubeColor = GetComponent<ColorChanger>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_coroutine == null)
        {
            _cubeColor.ChangeColor();

            _coroutine = StartCoroutine(ReturnAfterDelay(ChangeLifeTime()));
        }
    }

    private IEnumerator ReturnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Disappear();
    }

    private void Disappear()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
        }

        _cubeColor.BackToInitialColor();

        TriggerRelease();
    }

    private float ChangeLifeTime()
    {
        return Random.Range(_minLifeTime, _maxLifeTime + 1);
    }

    private void TriggerRelease()
    {
        Release?.Invoke(this);
    }
}
