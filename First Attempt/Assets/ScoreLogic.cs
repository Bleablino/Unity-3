using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    public int score = 0;
    private int collectedCoins = 0;
    [SerializeField]
    public TMP_Text TTS;
    // Start is called before the first frame update
    void Start()
    {
        TTS.text += score;
    }

    // Update is called once per frame
    void Update()
    {
        //collectedCoins = GameObject.Find("BCoin").GetComponent<CoinLogic>().coins;
        //score = 0 + collectedCoins;
    }
}
