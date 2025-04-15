using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinCounter : MonoBehaviour
{
    public TextMeshProUGUI coinCounter;

    // Update is called once per frame
    void Update()
    {
        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        coinCounter.text = "Coins left: " + coins.Length;
    }
}
