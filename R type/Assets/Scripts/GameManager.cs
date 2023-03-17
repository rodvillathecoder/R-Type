using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public Enemies enemigo;
    private GameObject Player;
    public Vector2 LimitesMov;
    public float SpeedPlayer;
    //public float Timer = 2;
    //private float TotalSpeed;
    //public float EnemySpeed;
    //public GameObject NewEnemy;

    private WorldCreator.WorldProperties CurrentWorld;
    //private List<GameObject> SavedEnemies;


    void Start()
    {
        PrintStage();

        //PrintEnemies();
        enemigo = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemies>();
       

    }

    void Update()
    {
        PlayerMovement();
        enemigo.Enemymovement();

        enemigo.EnemyInstantiate();


    }

    private void PrintStage()
    {
        //Imprimir mundo
        CurrentWorld = WorldCreator.GetWorldID(0);
        print(CurrentWorld.Name);




        //Imprimir jugador
        Player = GameObject.CreatePrimitive(PrimitiveType.Quad);
        Player.name = "Jugador";
        Player.transform.position = new Vector2(-8, 0);
        Destroy(Player.GetComponent<MeshCollider>());
        Player.GetComponent<MeshRenderer>().enabled = false;

        StartCoroutine(AddCollider(Player));



        //poner sprite al player
        GameObject SpritePlayer = new GameObject("Player Sprite");
        SpritePlayer.transform.SetParent(Player.transform);
        SpritePlayer.transform.localPosition = new Vector2(0, 0);
        SpritePlayer.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("naveplayer");




    }
    //public void PrintEnemies()
    //{
        //SavedEnemies = new List<GameObject>();
        //TotalSpeed = 0.1f;
        //Timer -= Time.deltaTime;
        //Imprimir enemigos
        /**for (int i = 0; i < CurrentWorld.NumeroEnemigos; i++)
        {
            NewEnemy = GameObject.CreatePrimitive(PrimitiveType.Quad);
            //if (Timer <= 0f)
            //{
            //   Instantiate(NewEnemy, new Vector3(11, Random.Range(5f, -5f), 0), Quaternion.identity);

            //}
            NewEnemy.name = "Enemigo ";
            //NewEnemy.transform.position = new Vector2(11, Random.Range(5f, -5f));
            Destroy(NewEnemy.GetComponent<MeshCollider>());
            NewEnemy.GetComponent<MeshRenderer>().enabled = false;

            StartCoroutine(AddCollider(NewEnemy));

            //poner sprite
            GameObject SpriteEnemy = new GameObject("Enemy Sprite");
            SpriteEnemy.transform.SetParent(NewEnemy.transform);
            //SpriteEnemy.transform.localPosition = new Vector2(0,0);
            SpriteEnemy.AddComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("naveenemy");



            //SavedEnemies.Add(NewEnemy);

            
        }**/
    //}

    //Para hacer esperar la función
    IEnumerator AddCollider(GameObject _obj)
    {
        yield return new WaitForSeconds(0.1f);
        _obj.AddComponent<BoxCollider2D>().isTrigger = true;
        _obj.AddComponent<Rigidbody2D>().gravityScale = 0;
    }

    private void PlayerMovement()
    {
        Player.transform.Translate(Vector2.up * SpeedPlayer * Input.GetAxis("Vertical") * Time.deltaTime);
        //limitar movimiento
        Vector2 CurrentPos = Player.transform.position;
        CurrentPos.y = Mathf.Clamp(CurrentPos.y, LimitesMov.y, LimitesMov.x);
        Player.transform.position = CurrentPos;

    }

    

    
}
