using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextHealthUI : MonoBehaviour
{
    public Player current_player;
    public Text Health_text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health_text.text = "Health : " + current_player.health + " / " + current_player.maxHealth;
    }
}
