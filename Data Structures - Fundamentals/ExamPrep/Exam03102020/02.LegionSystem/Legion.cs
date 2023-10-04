namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using _02.LegionSystem.Interfaces;
    using _02.LegionSystem.Models;

    public class Legion : IArmy
    {
        private readonly Dictionary<int, IEnemy> armies = new Dictionary<int, IEnemy>();

        public int Size
            => this.armies.Count;

        public bool Contains(IEnemy enemy)
            => this.armies.ContainsKey(enemy.AttackSpeed);

        public void Create(IEnemy enemy)
        {
            if (!this.armies.ContainsKey(enemy.AttackSpeed))
            {
                this.armies.Add(enemy.AttackSpeed, enemy);
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            if (!this.armies.ContainsKey(speed))
            {
                return null;
            }

            return this.armies[speed];
        }

        public List<IEnemy> GetFaster(int speed)     
            => this.armies.Keys
                .Where(a => a > speed)
                .OrderBy(a => a)
                .Select(a => this.armies[a])
                .ToList();

        public IEnemy GetFastest()
        {
            ValidateLegion();

            var result = this.armies
                .OrderBy(a => a.Key)
                .Last()
                .Value;

            return result;
        }

        public IEnemy[] GetOrderedByHealth()        
            => this.armies
                .OrderByDescending(a => a.Value.Health)
                .Select(a => a.Value)
                .ToArray();       

        public List<IEnemy> GetSlower(int speed)      
            => this.armies.Keys
                .Where(a => a < speed)
                .OrderByDescending(a => a)
                .Select(a => this.armies[a])
                .ToList();       

        public IEnemy GetSlowest()
        {
            ValidateLegion();

            var result = this.armies
                .OrderBy(a => a.Key)
                .First()
                .Value;

            return result;
        }

        public void ShootFastest()
        {
            ValidateLegion();

            var result = this.armies
                .OrderBy(a => a.Key)
                .Last()
                .Key;

            this.armies.Remove(result);
        }

        public void ShootSlowest()
        {
            ValidateLegion();

            var result = this.armies
                .OrderByDescending(a => a.Key)
                .Last()
                .Key;

            this.armies.Remove(result);
        }

        private void ValidateLegion()
        {
            if (this.armies.Count == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
