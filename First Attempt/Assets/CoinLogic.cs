using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    [SerializeField]
    private int coins = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        coins = coins + 10;
        Destroy(gameObject);
    }
}
