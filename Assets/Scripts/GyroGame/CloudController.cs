using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private float speed = 0.01f;

    private float maxVerticalPosition;
    private Vector2 endPosition;

    // Start is called before the first frame update
    private void OnEnable()
    {
        maxVerticalPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, Random.value)).x;
        endPosition = new Vector2(maxVerticalPosition + 1, transform.position.y );

        StartCoroutine(cloudWave(speed));
    }

    void Update()
    {
        if (transform.position.x > maxVerticalPosition)
        {
            gameObject.SetActive(false);
        }

    }

    IEnumerator cloudWave(float duration)
    {
        float elapsedTime = 0;

        Vector2 startPosition =  transform.position;


        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / duration));
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
         
    }
}
