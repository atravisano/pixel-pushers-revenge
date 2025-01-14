﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        private Stopwatch _stopWatch;

        void OnTriggerStay2D(Collider2D collider)
        {
            if (_stopWatch != null && _stopWatch.ElapsedMilliseconds >= 500)
            {
                _stopWatch.Restart();

                var p = collider.gameObject.GetComponent<PlayerController>();
                if (p != null)
                {
                    var ev = Schedule<PlayerEnteredDeathZone>();
                    ev.deathzone = this;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                _stopWatch = Stopwatch.StartNew();

                var ev = Schedule<PlayerEnteredDeathZone>();
                ev.deathzone = this;
            }
        }
    }
}