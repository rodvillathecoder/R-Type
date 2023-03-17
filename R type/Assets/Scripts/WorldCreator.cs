using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour
{
   public class WorldProperties
    {
        public string Name;
        public int ID;
        public int PlayerLife;
        public int Score;

        public int NumeroEnemigos;
        public List<int> EnemiesID;
    }

    static public List<WorldProperties> Worlds = new List<WorldProperties>()
    {
        new WorldProperties()
        {
            Name = "Mundo", ID = 0, PlayerLife = 3, NumeroEnemigos = 0,
            Score = 0, EnemiesID = new List<int>(){0,1}
        },
        new WorldProperties()
        {
            Name = "Mundo1", ID = 1, PlayerLife = 3, NumeroEnemigos = 0,
            Score = 0, EnemiesID = new List<int>(){0,1}
        }
    };
    static public WorldProperties GetWorldID(int _id)
    {
        for (int i = 0; i < Worlds.Count; i++)
        {
            if(Worlds[i].ID == _id)
            {
                return Worlds[i];
            }
        }
        return null;
    }
}
