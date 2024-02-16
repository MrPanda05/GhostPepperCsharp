using Godot;
using System;
using EnemyNeeds;
using Commons.Components;

namespace Commons.Singletons
{
    public partial class GlobalStats : Node
    {
        public static GlobalStats Instance {  get; private set; }

        public static int score = 0;

        public static int roundCount = 0;




        public static void AddScore()
        {
            score++;
        }
        public static void AddScore(int amount)
        {
            score += amount;
        }

        public override void _Ready()
        {
            Instance = this;
            Enemy.OnEnemyDeath += AddScore;
        }
    }
}


