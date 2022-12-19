using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public Player player;
    public GameObject MutliplierText;
    private TextMeshProUGUI tmp;
    public int Multiplier = 1;
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
        tmp.text = "SCORE: " + System.Math.Round(score).ToString();
    }

    public void PowerUpStart()
    {
        Multiplier = Random.Range(2, 6);
        MutliplierText.SetActive(true);
        MutliplierText.GetComponent<TextMeshProUGUI>().text = Multiplier.ToString() + "x";
        StartCoroutine(PowerUpEndCoroutine());
    }

    private IEnumerator PowerUpEndCoroutine()
    {
        yield return new WaitForSeconds(5);
        Multiplier = 1;
        MutliplierText.GetComponent<TextMeshProUGUI>().text = Multiplier.ToString() + "x";
        MutliplierText.SetActive(false);
    }

    public void OnFlipCamera()
    {
        Multiplier = -1;
    }
    
    public void OnFlipCameraBack()
    {
        Multiplier = 1;
    }
}
