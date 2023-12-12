using UnityEngine;
using System.Collections;

public class Up : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0f, 2.5f, -2f);
    public float arrivalDistance = 0.1f;
    public float transitionDuration = 1.25f;

    private bool hasArrived = false;
    private Vector3 startPosition;
    private float elapsedTime = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!hasArrived && Vector3.Distance(GameObject.Find("Player").transform.position, targetPosition) < arrivalDistance)
        {
            hasArrived = true;
            StartCoroutine(SmoothTransition());
        }
    }

    IEnumerator SmoothTransition()
    {
        while (elapsedTime < transitionDuration)
        {
            transform.position = Vector3.Lerp(startPosition, new Vector3(0f, 0f, 0f), elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = new Vector3(0f, 0f, 0f);
    }
}
