using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public class EnemyProperties
    {
        public int ID;
        public int lives;

    }
    static public List<EnemyProperties> Enemies = new List<EnemyProperties>()
    {
        new EnemyProperties(){ID=0, lives=4},
        new EnemyProperties(){ID=1, lives=7}
    };
    static public EnemyProperties CloneEnemy(EnemyProperties _enemy)
    {
        EnemyProperties NewEnemy = new EnemyProperties
        {
            ID = _enemy.ID,
            lives = _enemy.lives,
        };
        return NewEnemy;
    }
    static public EnemyProperties GetEnemyID(int _id)
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            if(Enemies[i].ID == _id)
            {
                return CloneEnemy(Enemies[i]);
            }
        }
        return null;
    }
  
}
