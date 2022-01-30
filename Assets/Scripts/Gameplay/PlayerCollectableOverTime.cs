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
    /// Fired when the player gains collectable over time.
    /// </summary>
    /// <typeparam name="PlayerCollectableOverTime"></typeparam>
    public class PlayerCollectableOverTime : Simulation.Event<PlayerCollectableOverTime>
    {
        public static float TimeBetweenCollects = 1000000000L * 10L;

        public float CollectableOverTime { get; set; }

        public override void Execute()
        {
            var ev = Simulation.Schedule<PlayerCollectableOverTime>(TimeBetweenCollects);
            ev.CollectableOverTime = CollectableOverTime;
        }
    }
}