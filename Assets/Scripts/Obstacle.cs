using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        StartCoroutine(WaitForDeath());
    }

    private IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
