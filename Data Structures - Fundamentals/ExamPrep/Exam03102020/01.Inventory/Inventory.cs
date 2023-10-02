using System.Linq;

namespace _01.Inventory
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;

    public class Inventory : IHolder
    {
        private readonly Dictionary<int, IWeapon> weapons;

        public Inventory()
        {
            this.weapons = new Dictionary<int, IWeapon>();
        }

        public int Capacity => this.weapons.Count;

        public void Add(IWeapon weapon)
            => this.weapons.Add(weapon.Id, weapon);

        public void Clear()
            => this.weapons.Clear();

        public bool Contains(IWeapon weapon)
            => this.weapons.ContainsKey(weapon.Id);

        public void EmptyArsenal(Category category)
        {
            var weapons = this.weapons.Values;
            foreach (var weapon in weapons.Where(w => w.Category == category))
            {
                weapon.Ammunition = 0;
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            IsWeaponExist(weapon);

            if (weapon.Ammunition >= ammunition)
            {
                weapon.Ammunition -= ammunition;

                return true;
            }

            return false;
        }

        public IWeapon GetById(int id)
            => this.weapons[id];

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < this.weapons.Count; i++)
            {
                yield return this.weapons[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        public int Refill(IWeapon weapon, int ammunition)
        {
            IsWeaponExist(weapon);

            if (weapon.Ammunition + ammunition > weapon.MaxCapacity)
            {
                weapon.Ammunition = weapon.MaxCapacity;
            }
            else
            {
                weapon.Ammunition += ammunition;
            }

            return weapon.Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            var weapon = this.GetById(id);

            IsWeaponExist(weapon);
            this.weapons.Remove(id);

            return weapon;
        }

        public int RemoveHeavy()
        {
            var weapons = this.weapons.Values.Where(w => w.Category == Category.Heavy);
            int weaponsCount = weapons.Count();

            foreach (var weapon in weapons)
            {
                this.weapons.Remove(weapon.Id);
            }

            return weaponsCount;
        }

        public List<IWeapon> RetrieveAll()
        {
            var weapons = this.weapons.Values.ToList();

            return weapons;
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            var lowerWeapons = this.weapons.Values.Where(w => w.Category >= lower);
            var upperWeapons = this.weapons.Values.Where(w => w.Category <= upper);

            var weapons = lowerWeapons.Intersect(upperWeapons).ToList();

            return weapons;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            IsWeaponExist(firstWeapon);
            IsWeaponExist(secondWeapon);

            if (firstWeapon.Category == secondWeapon.Category)
            {
                IWeapon temp = firstWeapon;
                this.weapons[firstWeapon.Id] = secondWeapon;
                this.weapons[secondWeapon.Id] = temp;
            }
        }

        private void IsWeaponExist(IWeapon weapon)
        {
            if (!this.Contains(weapon))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }
        }
    }
}
