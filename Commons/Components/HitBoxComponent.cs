using Godot;
using System;


namespace Commons.Components
{
	public partial class HitBoxComponent : Area2D
	{
		[Export] private HealthComponent healthComponent;
		public void Damage(float amount = 1)
		{
			healthComponent?.Damage(amount);
		}
        public void DamageNon(float amount = 1)
        {
            healthComponent?.DamageNon(amount);
        }
    }
}
