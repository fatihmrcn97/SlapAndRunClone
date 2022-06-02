using System.Collections;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public bool isFollowingPlayer;
    private void Start()
    {
        isFollowingPlayer = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("obstacle"))
        {   
            // kill the enemy
            gameObject.SetActive(false);
            //sound effect

            //

        }

        if (other.gameObject.CompareTag("Player"))
        {
            // kill player
            if (isFollowingPlayer)
            {
                other.gameObject.GetComponentInChildren<Animator>().SetTrigger("die");
                isFollowingPlayer = false;
                other.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                LevelManager.instance.gameFlow = false;
                other.gameObject.GetComponent<PlayerTriggerController>().dieSound.Play();
            }
        }
    }

    public IEnumerator MakeFollowingTrue()
    {
        yield return new WaitForSeconds(1.5f);
        isFollowingPlayer = true;
    }
}
