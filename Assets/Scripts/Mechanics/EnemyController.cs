using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// The Mover class oscillates between start and end points of a path at a defined speed.
    /// </summary>
    public class Mover
    {
        EnemyController enemy;
        float p = 0;
        float duration;
        float startTime;
        private readonly float _minX;
        private readonly float _maxX;

        public Mover(EnemyController enemy, float speed)
        {
            this.enemy = enemy;

            _minX = enemy.transform.position.x + enemy.startPosition;
            _maxX = enemy.transform.position.x + enemy.endPosition;


            this.duration = (enemy.endPosition - enemy.startPosition) / speed;
            this.startTime = Time.time;
        }

        /// <summary>
        /// Get the position of the mover for the current frame.
        /// </summary>
        /// <value></value>
        public Vector2 Position
        {
            get
            {
                p = Mathf.InverseLerp(0, duration, Mathf.PingPong(Time.time - startTime, duration));
                var position = Vector2.Lerp(new Vector2(_minX, 0), new Vector2(_maxX, 0), p);

                return position;
            }
        }
    }

    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public AudioClip ouch;

        public bool patrol = false;

        public float startPosition = -1;
        public float endPosition = 1;

        internal Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
            }
        }

        void Update()
        {
            if (patrol)
            {
                if (mover == null)
                {
                    mover = CreateMover(control.maxSpeed * 0.5f);
                }

                var move = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);

                control.move.x = move;
            }
        }

        /// <summary>
        /// Create a Mover instance which is used to move an entity along the path at a certain speed.
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public Mover CreateMover(float speed = 1) => new Mover(this, speed);
    }
}