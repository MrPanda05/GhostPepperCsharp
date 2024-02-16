using Godot;
using System;
using Commons.Components;

namespace EnemyNeeds
{
    public partial class Enemy : CharacterBody2D
    {
        private HealthComponent healthComponent;

        public static Action OnEnemyDeath;

        public void UpdateScore()
        {
            Visible = false;
            ProcessMode = ProcessModeEnum.Disabled;
            OnEnemyDeath?.Invoke();
        }

        public override void _Ready()
        {
            healthComponent = GetNode<HealthComponent>("HealthComponent");
            healthComponent.OnDeath += UpdateScore;
        }
    }
}

