using Godot;
using System;

namespace Commons.Components
{
	public partial class HealthComponent : Node2D
	{
		[Export] private float MaxHealth;
		private float health;

		//public static Action OnDeath -> Static Action so it can be acted like enemy death or player, but this is too generic

		public Action OnHealthChange, OnDeath;
        public void Damage(float amount)
        {
			GD.Print(health);
			health -= amount;
			OnHealthChange?.Invoke();
            if(health <= 0) 
			{
				OnDeath?.Invoke();
				GetParent().QueueFree();
			}
        }
        public void DamageNon(float amount)
        {
            GD.Print(health);
            health -= amount;
            OnHealthChange?.Invoke();
            if (health <= 0)
            {
                OnDeath?.Invoke();
				Node2D test = (Node2D)GetParent();
				test.Visible = false;
				test.ProcessMode = ProcessModeEnum.Disabled;

			}
        }

        public float GetHealth()
		{
			return health;
		}
		public float GetMaxHealth()
		{
			return MaxHealth;
		}

		public void SetHealth(float amount)
		{
			health = amount;
            OnHealthChange?.Invoke();
        }
        public void SetMaxHealth(float amount)
		{
			MaxHealth = amount;
		}

		public override void _Ready()
		{
			health = MaxHealth;
		}
    }
}
