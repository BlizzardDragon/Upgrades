using System;
using System.Collections;
using Modules.AI;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Agents
{
    public abstract class Agent_FollowTargetByNavMesh : Agent
    {
        public event Action<bool> OnTargetReached;

        protected abstract Agent_MoveToTarget<Vector3> MoveAgent { get; }

        private readonly NavMeshPath currentPath = new();

        private int navMeshAreas;

        private bool isTargetReached;

        private Coroutine calculatePathCoroutine;

        private Coroutine checkTargetReachedCoroutine;

        private YieldInstruction calculatePathPeriod;

        private YieldInstruction checkTargetReachedPeriod;

        private float sqrStoppingDistance;

        public void SetNavMeshAreas(int navMeshAreas)
        {
            this.navMeshAreas = navMeshAreas;
        }

        public void SetCheckTargetReachedPeriod(YieldInstruction period)
        {
            this.checkTargetReachedPeriod = period;
        }

        public void SetCalculatePathPeriod(YieldInstruction period)
        {
            this.calculatePathPeriod = period;
        }

        public void SetStoppingDistance(float stoppingDistance)
        {
            this.sqrStoppingDistance = Mathf.Pow(stoppingDistance, 2);
        }

        protected override void OnStart()
        {
            this.isTargetReached = false;

            var context = MonoHelper.Instance;
            this.calculatePathCoroutine = context.StartCoroutine(this.CalculatePathRoutine());
            this.checkTargetReachedCoroutine = context.StartCoroutine(this.CheckTargetReachedRoutine());
            this.MoveAgent.Play();
        }

        protected override void OnStop()
        {
            this.MoveAgent.Stop();

            var context = MonoHelper.Instance;
            if (this.calculatePathCoroutine != null)
            {
                context.StopCoroutine(this.calculatePathCoroutine);
                this.calculatePathCoroutine = null;
            }

            if (this.checkTargetReachedCoroutine != null)
            {
                context.StopCoroutine(this.checkTargetReachedCoroutine);
                this.checkTargetReachedCoroutine = null;
            }
        }

        private IEnumerator CheckTargetReachedRoutine()
        {
            while (true)
            {
                yield return this.checkTargetReachedPeriod;
                this.UpdateTargetReach();
            }
        }

        private IEnumerator CalculatePathRoutine()
        {
            while (true)
            {
                yield return this.calculatePathPeriod;
                this.CalculateNextPoint();
            }
        }

        private void UpdateTargetReach()
        {
            var isTargetReached = this.CheckTargetReached();

            if (isTargetReached && !this.isTargetReached)
            {
                this.isTargetReached = true;
                this.OnTargetReached?.Invoke(true);
            }

            if (!isTargetReached && this.isTargetReached)
            {
                this.isTargetReached = false;
                this.OnTargetReached?.Invoke(false);
            }
        }

        private void CalculateNextPoint()
        {
            var currentPosition = this.EvaluateCurrentPosition();
            var targetPosition = this.EvaluateTargetPosition();

            if (!NavMesh.CalculatePath(currentPosition, targetPosition, this.navMeshAreas, this.currentPath))
            {
                return;
            }

            var pathCorners = this.currentPath.corners;
            if (pathCorners.Length < 2)
            {
                return;
            }

            var nextPosition = pathCorners[1];
            this.MoveAgent.SetTarget(nextPosition);
        }

        private bool CheckTargetReached()
        {
            var distanceVector = this.EvaluateTargetPosition() - this.EvaluateCurrentPosition();
            return distanceVector.sqrMagnitude <= this.sqrStoppingDistance;
        }

        protected abstract Vector3 EvaluateCurrentPosition();

        protected abstract Vector3 EvaluateTargetPosition();
    }
}