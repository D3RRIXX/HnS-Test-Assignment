using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace HnS.Characters.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyAI : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private float _changePointCooldown;
        
        private NavMeshAgent _agent;
        private Coroutine _moveToPointRoutine;

        public Vector3 Velocity => _agent.velocity;
        public float MaxSpeed => _agent.speed;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
        }

        private void Start()
        {
            if (_patrolPoints.Length == 0)
            {
                Debug.LogException(new ArgumentException("No patrol points assigned!"), this);
                return;
            }
            
            StartMovingToPoint(0);
        }

        private void StartMovingToPoint(int pointIndex)
        {
            _moveToPointRoutine = StartCoroutine(MoveToPoint(pointIndex));
        }

        private IEnumerator MoveToPoint(int pointIndex)
        {
            _agent.SetDestination(_patrolPoints[pointIndex].position);

            yield return new WaitUntil(() => Vector3.Distance(transform.position, _agent.destination) <= 0.1f);
            yield return new WaitForSeconds(_changePointCooldown);

            int nextIndex = (pointIndex + 1) % _patrolPoints.Length;

            StartMovingToPoint(nextIndex);
        }
    }
}
