using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject NewEnemy;
    public int live;
    public int speed;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemymovement();
    }

    public void Enemymovement()
    {
        NewEnemy.transform.position = new Vector2(-1, 0 * speed * Time.deltaTime);

    }

    public void EnemyInstantiate()
    {
        for (int i = 0; i < 20; i++)
        {
            Instantiate(NewEnemy, new Vector3(11, Random.Range(5f, -5f), 0), Quaternion.identity);
        }


    }
}
