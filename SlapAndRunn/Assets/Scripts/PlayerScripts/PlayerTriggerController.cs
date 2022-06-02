
using UnityEngine;

public class PlayerTriggerController : MonoBehaviour
{
    public Animator slapAnim;
    public PlayerMovementSO playerMovementSO;
    public AudioSource slapSound,dieSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("enemyLeft"))
        {
            // Slap Anim
            slapAnim.SetBool("slapR", true);
            // Slap Action
            other.gameObject.GetComponentInParent<Animator>().SetTrigger("gethitleft");
            // slap sound
            slapSound.Play();
            // Follow the player
            StartCoroutine(other.gameObject.GetComponentInParent<EnemyMovement>().waitForFollow());

            // set player tocuhble buy enemy 
            StartCoroutine(other.gameObject.GetComponentInParent<EnemyTrigger>().MakeFollowingTrue());

        }


        if (other.gameObject.CompareTag("enemyRight"))
        {
            // Slap Anim
            slapAnim.SetBool("slapL", true);
            // Slap Action
            other.gameObject.GetComponentInParent<Animator>().SetTrigger("gethit");
            // slap sound
            slapSound.Play();
            // Follow the player
            StartCoroutine(other.gameObject.GetComponentInParent<EnemyMovement>().waitForFollow());

            // set player tocuhble buy enemy 
            StartCoroutine(other.gameObject.GetComponentInParent<EnemyTrigger>().MakeFollowingTrue());

        }


        if (other.gameObject.CompareTag("speedup"))
        {
            StartCoroutine(playerMovementSO.MakeFasterForSec());
        }

        if (other.gameObject.CompareTag("obstacle"))
        {
            //stop the game
            LevelManager.instance.gameFlow = false;
            // stop retouch again and again
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            // game end restart after while
            StartCoroutine(LevelManager.instance.ReStartGame());
            //get hurt sound effect
            dieSound.Play();
            // die anim
            slapAnim.SetTrigger("die");
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            //finish sound effect

            // Stop the game open the finish ui
            LevelManager.instance.PauseGame();


        }


    }

    private void OnTriggerExit(Collider other)
    {
        slapAnim.SetBool("slapR", false);
        slapAnim.SetBool("slapL", false);
    }




}
