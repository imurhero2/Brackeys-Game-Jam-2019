using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().StopMusic("Boss Music");
        FindObjectOfType<AudioManager>().Play("Credits");
    }
    
}
