using Commons.Components;
using Godot;
using System;
using System.Diagnostics;


namespace PlayerNeeds
{
	public partial class Flame : Node2D
	{

		[Export] private Vector2 playerPos;
		private Player player;
		private Vector2 mousePos;
		private Transform2D myPos;



		public void OnHitBoxComponentAreaEntered(Area2D area)
		{
			if(area is HitBoxComponent)
			{
				HitBoxComponent hitbox = area as HitBoxComponent;
                hitbox.DamageNon();
			}
		}
        public override void _Ready()
		{
			player = GetNode<Player>("..");
		}

		
		//Maybe use Process instead
        public override void _PhysicsProcess(double delta)
        {
            myPos = GlobalTransform;
            mousePos = GetGlobalMousePosition();
            myPos.Origin = mousePos;
            GlobalTransform = myPos;
        }
    }
}
