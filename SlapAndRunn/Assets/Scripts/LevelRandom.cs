using System.Collections;
using UnityEngine;

public class LevelRandom : MonoBehaviour
{

     
    private Vector3 randomPos;
    public GameObject moveFasterObj;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        int enemyListCount =14;
        int fiveEnemyRight = 2;
        int fiveEnemyLeft = 2;
        while (enemyListCount > 1)
        {
            randomPos = new Vector3(Random.Range(-4,4), 0, Random.Range(30, 150));
            enemyListCount--;
            GameObject obj = PoolSystem.instance.SpawnFromPool("enemy",this.gameObject.transform);
            obj.transform.position = randomPos;

        }

        while (fiveEnemyRight > 1)
        {
            randomPos = new Vector3(Random.Range(-4, 4), -17, Random.Range(30, 150));
            fiveEnemyRight--;
            GameObject obj = PoolSystem.instance.SpawnFromPool("5enemyRight", this.gameObject.transform);
            obj.transform.position = randomPos;

        }
        while (fiveEnemyLeft > 1)
        {
            randomPos = new Vector3(Random.Range(-4, 4), -17, Random.Range(30, 150));
            fiveEnemyLeft--;
            GameObject obj = PoolSystem.instance.SpawnFromPool("5enemyLeft", this.gameObject.transform);
            obj.transform.position = randomPos;

        }

        GameObject fasterObjects = Instantiate(moveFasterObj);
        fasterObjects.transform.position= new Vector3(Random.Range(-3, 3), 0.03f, Random.Range(60,100));
    }

}
