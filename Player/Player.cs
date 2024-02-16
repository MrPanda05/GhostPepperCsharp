using Godot;
using System;
using Commons.Components;

namespace PlayerNeeds
{
    public partial class Player : CharacterBody2D
    {
        private HealthComponent healthComponent;
        private HitBoxComponent hitBoxComponent;
        [Export] private float speed = 300f;
        private Vector2 direction;

        public override void _Ready()
        {
            healthComponent = GetNode<HealthComponent>("HealthComponent");
            hitBoxComponent = GetNode<HitBoxComponent>("HitBoxComponent");
        }

        public override void _PhysicsProcess(double delta)
        {
            direction = Input.GetVector("Left", "Right", "Up", "Down").Normalized();
            Velocity = direction * speed;
            MoveAndSlide();
        }
    }
}

