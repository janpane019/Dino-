using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Player player;
    public GameObject MutliplierText;
    private TextMeshProUGUI tmp;
    public float Multiplier = 1.0f;
    private float score = 0;
    private float lastPosX = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        MutliplierText.SetActive(false);
    }

    private void Update()
    {
        score += (player.transform.position.x - lastPosX) * Multiplier;
        lastPosX = player.transform.position.x;
        tmp.text = "SCORE: " + Math.Round(score).ToString();
    }

    public void PowerUpStart()
    {
        Multiplier = 4.0f;
        MutliplierText.SetActive(true);
    }

    public void PowerUpEnd()
    {
        StartCoroutine(PowerUpEndCoroutine());
    }

    private IEnumerator PowerUpEndCoroutine()
    {
        yield return new WaitForSeconds(5);
        Multiplier = 1.0f;
        MutliplierText.SetActive(false);
    }
}
