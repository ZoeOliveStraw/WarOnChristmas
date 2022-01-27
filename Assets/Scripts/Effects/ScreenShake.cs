using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Transform transform;
    private float shakeDuration = 0f;
    private float shakeMagnitude = 0f;

    [SerializeField] Vector2 small;
    [SerializeField] Vector2 medium;
    [SerializeField] Vector2 large;
    private float dampingSpeed = 1f;

    private Vector3 initialPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        if(transform == null)
        {
            transform = GetComponent<Transform>();
        }
    }

    private void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenShakeMethod();
    }

    private void ScreenShakeMethod()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    private void TriggerScreenShake(float duration,float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
    }

    public void ScreenShakeSmall()
    {
        TriggerScreenShake(small.x, small.y);
    }
    public void ScreenShakeMedium()
    {
        TriggerScreenShake(medium.x, medium.y);
    }
    public void ScreenShakeLarge()
    {
        TriggerScreenShake(large.x, large.y);
    }
}
