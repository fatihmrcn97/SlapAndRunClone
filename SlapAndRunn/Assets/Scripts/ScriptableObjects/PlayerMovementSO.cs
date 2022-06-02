using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/PlayerMovement")]
public class PlayerMovementSO : ScriptableObject
{
    public float xSpeed;
    public float _currentRunningSpeed;

    private float holdSpeed;

    public IEnumerator MakeFasterForSec()
    {
        holdSpeed = _currentRunningSpeed;
        _currentRunningSpeed += 1.5f;
        yield return new WaitForSeconds(2);
        _currentRunningSpeed = holdSpeed;
    }
 
}
