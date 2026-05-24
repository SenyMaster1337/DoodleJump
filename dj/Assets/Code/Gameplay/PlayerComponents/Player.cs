using System;
using UnityEngine;

namespace Code.Gameplay.PlayerComponents
{
    public class Player : MonoBehaviour
    {
        public event Action Dead;

        public void Die()
            => Dead?.Invoke();
    }
}