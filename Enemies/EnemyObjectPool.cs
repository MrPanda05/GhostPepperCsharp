using Godot;
using System;
using System.Collections.Generic;

namespace EnemyNeeds
{
	public partial class EnemyObjectPool : Node2D
	{
		[Export] private PackedScene EnemyScene;

		internal List<CharacterBody2D> enemyList;

        private float growthRate = 1.5f;

        private int maxEnemies = 20;
        private int enemyCount = 0;

        public override void _Ready()
        {
            enemyList = new List<CharacterBody2D>();
            for (int i = 0; i < maxEnemies; i++)
            {
                CharacterBody2D newEnemy = EnemyScene.Instantiate<CharacterBody2D>();
                //GD.Print($"local {newEnemy.Position} global {newEnemy.GlobalPosition}");
                newEnemy.Visible = false;
                AddChild(newEnemy);
                enemyList.Add(newEnemy);
            }
        }
    }
}
