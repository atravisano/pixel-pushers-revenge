using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when a player enters a trigger with a DeathZone component.
    /// </summary>
    /// <typeparam name="PlayerEnteredDeathZone"></typeparam>
    public class PlayerEnteredDeathZone : Simulation.Event<PlayerEnteredDeathZone>
    {
        public DeathZone deathzone;

        public override void Execute()
        {
            var player = GameController.Instance.model.player;

            if (!player.IsInvincible)
            {
                player.animator.SetTrigger("hurt");

                player.health.Decrement();
            }

            if (!player.health.IsAlive)
            {
                Simulation.Schedule<PlayerDeath>(0);
            }
        }
    }
}