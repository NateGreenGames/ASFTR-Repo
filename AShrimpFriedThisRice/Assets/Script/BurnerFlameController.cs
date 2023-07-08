using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnerFlameController : MonoBehaviour
{
    public float minScale, maxScale;
    public float transitionTime;

    private Vector3 lastPosition, newPosition;

    private void OnEnable()
    {
        StartCoroutine(ChangeFlame());
    }

    private IEnumerator ChangeFlame()
    {
        float elapsedTime = 0;
        newPosition = new Vector3(Random.Range(minScale, maxScale), Random.Range(minScale, maxScale), Random.Range(minScale, maxScale));
        while (elapsedTime < transitionTime)
        {
            transform.localScale = Vector3.Lerp(lastPosition, newPosition, Mathf.InverseLerp(0, transitionTime, elapsedTime));
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
        }
        transform.localScale = newPosition;
        lastPosition = newPosition;
        StartCoroutine(ChangeFlame());
    }
}
