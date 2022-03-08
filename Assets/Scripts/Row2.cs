using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row2 : MonoBehaviour
{
    public AudioSource spinStop;
    public GameHandler gameHandler;
    public bool canRotate2 = true;

    private int randomValue = 0;

    private float timeInterval;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(0.15f, 13.8f), transform.position.z);
    }

    public void StartRotating()
    {
        if (canRotate2 && gameHandler.enoughMoney)
        {
            transform.position = new Vector3(transform.position.x, Random.Range(0.15f, 13.8f), transform.position.z);
            randomValue = 0;
            StartCoroutine(Rotate());
            StartCoroutine(RandomValue());
            canRotate2 = false;
        }
    }

    IEnumerator Rotate()
    {
        timeInterval = 0.025f;

        while (true)
        {
            if (randomValue < 7)
            {
                if (transform.position.y <= 0.15)
                {
                    transform.position = new Vector3(transform.position.x, 13f, transform.position.z);
                }

                transform.position = new Vector3(transform.position.x, transform.position.y - 0.25f, transform.position.z);

                yield return new WaitForSeconds(timeInterval);
            }
            else
            {
                gameHandler.rowHasStoped++;
                randomValue = 0;
                break;
            }
        }
    }

    IEnumerator RandomValue()
    {
        while (randomValue < 7)
        {
            yield return new WaitForSeconds(1.5f);

            randomValue = Random.Range(1, 10);
        }
    }

    public void StopRows()
    {
        spinStop.Play();
        randomValue = 8;
    }
}
