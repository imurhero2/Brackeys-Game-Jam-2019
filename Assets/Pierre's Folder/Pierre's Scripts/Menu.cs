using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour
{
    public Player_Movement movement;
    [SerializeField] GameObject explosion;
    [SerializeField] SpriteRenderer player;
    private bool setOff = false;

    public void KillPlayer()
    {
        if (!setOff)
        {
            Debug.Log("Kill Player");
            movement.enabled = false;
            FindObjectOfType<AudioManager>().Play("Explode");
            player.enabled = false;
            explosion.SetActive(true);
            StartCoroutine(RemoveExplosion());
            setOff = true;
        }
    }

    IEnumerator RemoveExplosion()
    {
        yield return new WaitForSeconds(1);
        explosion.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
