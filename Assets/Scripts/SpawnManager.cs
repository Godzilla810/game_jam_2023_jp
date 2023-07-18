using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public LayerMask playerLayer;
    public LayerMask enemyLayer;
    public LayerMask wallLayer;
    public LayerMask floorLayer;

    public Transform roomRangeA;
    public Transform roomRangeB;

    public int initialEnemyAmount = 30; // 初始敵人數量
    public int maxEnemyAmount = 60; // 最大敵人數量
    private int currentEnemyAmount = 0; // 當前敵人數量

    private bool isCount = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(initialEnemyAmount);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnemyAmountOK() && !isCount)
        {
            StartCoroutine(Countdown());
        }
    }
    IEnumerator Countdown(){
        isCount = true;
        yield return new WaitForSeconds(1);
        SpawnEnemy(1);
        isCount = false;
    }
    //生成敵人
    void SpawnEnemy(int enemiesToSpawn){
        for (int i = 0; i < enemiesToSpawn; i++){
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], GenerateSpawnPoint(), 
            enemyPrefabs[enemyIndex].transform.rotation);
        }
    }
    void DeleteEnemy(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        Destroy(enemies[0]);
    }
    //生成位置
    private Vector2 GenerateSpawnPoint(){
        float spawnPosX = Random.Range(roomRangeA.position.x, roomRangeB.position.x);
        float spawnPosY = Random.Range(roomRangeA.position.y, roomRangeB.position.y);
        Vector2 randomPos = new Vector3(spawnPosX, spawnPosY);
        if (IsSpawnPointOK(randomPos)){
            return randomPos;
        }
        else{
            return GenerateSpawnPoint();
        }
    }
    //確認位置是否ok
    private bool IsSpawnPointOK(Vector2 spawnPoint){
        Collider2D colliderPlayer = Physics2D.OverlapCircle(spawnPoint, 10f, playerLayer);
        Collider2D colliderEnemy = Physics2D.OverlapCircle(spawnPoint, 2f, enemyLayer);
        Collider2D colliderWall = Physics2D.OverlapCircle(spawnPoint, 1f, wallLayer);
        Collider2D colliderFloor = Physics2D.OverlapCircle(spawnPoint, 0.2f, floorLayer);
        if (colliderPlayer != null || colliderWall != null || colliderEnemy != null){
            return false;
        }
        else if (colliderFloor != null){
            return true;
        }
        return false;
    }
    //確認總數是否ok
    private bool IsEnemyAmountOK(){
        currentEnemyAmount = GameObject.FindGameObjectsWithTag("enemy").Length;
        if (currentEnemyAmount > maxEnemyAmount){
            DeleteEnemy();
            return false;
        }
        return true;
    }
}
