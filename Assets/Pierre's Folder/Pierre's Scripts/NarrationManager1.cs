using UnityEngine;

public class NarrationManager1 : MonoBehaviour
{
    public bool spikeDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("1-1 intro");
    }
    
}
