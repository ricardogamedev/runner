using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementHelper : MonoBehaviour
{
    public List<Transform> positions;

    public float duration = 1f;

    private int _index = 0;

    private void Start()
    {
        transform.position = positions[0].transform.position;
        NextIndex();
        StartCoroutine(StartMovement());
    }

    private void NextIndex()
    {
        _index++;
        if (_index >= positions.Count) _index = 0;
    }

    IEnumerator StartMovement()
    {
        float timeElapsed = 0;

        while (true)
        {
            var currentPosition = transform.position;

            while (timeElapsed < duration)
            {
                transform.position = Vector3.Lerp(currentPosition, positions[_index].transform.position, (timeElapsed / duration));

                timeElapsed += Time.deltaTime;
                yield return null;
            }

            NextIndex();
            timeElapsed = 0;

            yield return null;
        }
    }
}
