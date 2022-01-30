using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Platformer.Core;
using Platformer.Mechanics;
using Platformer.Model;
using UnityEngine;

namespace Platformer.Gameplay
{
    /// <summary>
    /// Fired when the player becomes invincible.
    /// </summary>
    /// <typeparam name="PlayerInvincibility"></typeparam>
    public class PlayerInvincibility : Simulation.Event<PlayerInvincibility>
    {
        PlatformerModel model = Simulation.GetModel<PlatformerModel>();
        private Timer _timer;
        public float InvincibilityTime { get; set; }

        public override void Execute()
        {
            var player = model.player;

            if (player.audioSource && player.invincibleAudio)
            {
                player.audioSource.PlayOneShot(player.invincibleAudio);
            }

            GameController.Instance.model.player.IsInvincible = true;
            Debug.Log("Invincibility enabled!");

            _timer = new Timer((state) =>
            {
                Debug.Log("Invincibility disabled!");

                GameController.Instance.model.player.IsInvincible = false;
            }, null, (int)(InvincibilityTime * 1000), 0);

            player.animator.SetTrigger("invincible");
        }
    }
}