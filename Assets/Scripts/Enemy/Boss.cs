using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// press "O" to kill boss instantly, press "I" to damage boss
public class Boss : MonoBehaviour
{
    //實例化
    public static Boss instance;
    void Awake() {
        if (instance != null){
            return;
        }
        instance = this;
    }

    private Animator animator;
    public int dmgCount;
    private int dieCount;
    private Transform spawnPoint;

    public Transform ru,rd,lu,ld;
    public GameObject enemyPrefab;     // Prefab of the enemy to be generated
    private int hp;
    //private float minX;
    //private float maxX;
    //private float minY;
    //private float maxY;

    private void Start()
    {
        hp = 5;
        animator = GetComponent<Animator>();
        dmgCount=0;
        dieCount=0;
        //minX = Mathf.Min(ru.position.x, rd.position.x, lu.position.x, ld.position.x);
        //maxX = Mathf.Max(ru.position.x, rd.position.x, lu.position.x, ld.position.x);
        //minY = Mathf.Min(ru.position.y, rd.position.y, lu.position.y, ld.position.y);
        //maxY = Mathf.Max(ru.position.y, rd.position.y, lu.position.y, ld.position.y);
    }

    private void Update()
    {
        // Check for player input to switch between animator states
        if (Input.GetKeyDown(KeyCode.T))
        {
            // Trigger the "Jump" animation state
            animator.SetTrigger("Talk");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetTrigger("Dmg");
            GenerateNewEnemy();
            StartCoroutine(DelayOnHit());
        }
        else if (Input.GetKeyDown(KeyCode.O)||dmgCount==hp)
        {
            animator.SetTrigger("Die");
            dmgCount=0;
            dieCount++;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Idle");
        }
        if(dieCount==4){
            StartCoroutine(DestroyEnemyWithDelay());
        }
    } 

    IEnumerator DestroyEnemyWithDelay()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
    IEnumerator DelayOnHit()
    {
        yield return new WaitForSeconds(0.5f);
        dmgCount++;
    }
    private void GenerateNewEnemy(){
        //Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        //Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
    }
}

