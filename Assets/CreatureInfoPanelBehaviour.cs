﻿using UnityEngine;

public class CreatureInfoPanelBehaviour : MonoBehaviour
{
    public CreatureBehaviour Creature { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Creature != null) {
            
        } else if(gameObject.activeSelf) {
            gameObject.SetActive(false);
        }
    }
}
