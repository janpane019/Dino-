using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OneUps : MonoBehaviour
{
    public Player player;
    private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        tmp.text = "1UP: " + player.oneUps;
    }
}
