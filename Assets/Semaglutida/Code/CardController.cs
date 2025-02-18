using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CardController : MonoBehaviour
{
    [Header("- Enable -")]
    [SerializeField] UnityEvent OnEnableEvent;
    [SerializeField] float EnableDelay;
    [Header("- Deactivate -")]
    [SerializeField] UnityEvent OnDisableEvent;
    [SerializeField] float DisableDelay;
    [Header("- Loop -")]
    [SerializeField] bool LoopEnabled;
    [SerializeField] UnityEvent OnLoopEvent;
    [SerializeField] float LoopDelay;

    private void OnEnable()
    {
        StartCoroutine(OnEnableCoroutine());
    }
    private void OnDisable()
    {
        StopCoroutine(OnEnableCoroutine());
        StopCoroutine(OnLoopCoroutine());
    }

    private IEnumerator OnEnableCoroutine()
    {
        yield return new WaitForSeconds(EnableDelay);
        OnEnableEvent.Invoke();
        StartCoroutine(OnLoopCoroutine());
    }
    public void Deactivate()
    {
        StartCoroutine(OnDisableCoroutine());
    }

    private IEnumerator OnDisableCoroutine()
    {
        yield return new WaitForSeconds(DisableDelay);
        OnDisableEvent.Invoke();
    }
    private IEnumerator OnLoopCoroutine()
    {
        while (true)
        {
            if (LoopEnabled)
            {
                OnLoopEvent.Invoke();
                yield return new WaitForSeconds(LoopDelay);
            }
            yield return null;
        }
    }
}
