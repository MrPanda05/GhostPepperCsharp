using Godot;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EnemyNeeds
{ 
	public partial class Spawner : Node2D
	{
		//private List<Vector2> possibleSpawnPos = new List<Vector2>();

		private Timer timer;

		private EnemyObjectPool pool;

		public void OnTimerTimeout()
		{
			Spawn();
		}

        public void Spawn()
		{
			//if (pool.enemyList.All(emeny => emeny.Visible))
			//{
			//	GD.Print(1);
			//}
			pool.enemyList.Where(enemy => !enemy.Visible).ToList().ForEach(enemy =>
			{
				enemy.Visible = true;
				enemy.Position = new Vector2((float)GD.RandRange(0, 1920), (float)GD.RandRange(0, 1080));
				enemy.ProcessMode = ProcessModeEnum.Inherit;
            });
			//pool.enemyList[0].Visible = true;
			//pool.enemyList[0].GlobalPosition = new Vector2(50, 50);
			//pool.enemyList[0].ProcessMode = ProcessModeEnum.Inherit;
			

        }

        public override void _Ready()
        {
			pool = GetNode<EnemyObjectPool>("EnemyObjectPool");
			timer = GetNode<Timer>("Timer");
        }
    }
}
