namespace RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Arena : IArena
    {
        private Dictionary<int, BattleCard> cardsById;

        public Arena()
        {
            this.cardsById = new Dictionary<int, BattleCard>();
        }

        public int Count => this.cardsById.Count;

        /// <summary>
        /// Checks cardsById dictionary for the given card.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool Contains(BattleCard card)
            => this.cardsById.ContainsKey(card.Id);

        /// <summary>
        /// Get card by id from cardsById dictionary.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public BattleCard GetById(int id)
        {
            if (!this.cardsById.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.cardsById[id];
        }

        public void Add(BattleCard card)
        {
            if (!Contains(card))
            {
                this.cardsById.Add(card.Id, card);
            }
        }

        public void ChangeCardType(int id, CardType type)
        {
            if (!Contains(GetById(id)))
            {
                throw new InvalidOperationException();
            }

            this.cardsById[id].Type = type;
        }

        public void RemoveById(int id)
        {
            if (!Contains(GetById(id)))
            {
                throw new InvalidOperationException();
            }

            this.cardsById.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            var cards = this.cardsById.Values
                .Where(c => c.Type == type)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id)
                .ToList();

            GeneralError(cards);

            return cards;
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            if (n > this.cardsById.Count)
            {
                throw new InvalidOperationException();
            }

            var cards = this.cardsById.Values
                .OrderBy(c => c.Swag)
                .ThenBy(c => c.Id)
                .Take(n)
                .ToList();

            return cards;
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
            => this.cardsById
                .Where(c => c.Value.Swag >= lo && c.Value.Swag <= hi)
                .Select(c => c.Value)
                .OrderBy(c => c.Swag)
                .ToList();

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            var cards = this.cardsById.Values
                .Where(c => c.Type == type && c.Damage <= damage)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id)
                .ToList();

            GeneralError(cards);

            return cards;
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            var cards = this.cardsById.Values
                .Where(c => c.Name == name && c.Swag >= lo && c.Swag < hi)
                .OrderByDescending(c => c.Id)
                .ToList();

            GeneralError(cards);

            return cards;
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            var cards = this.cardsById.Values
                .Where(c => c.Name == name)
                .OrderByDescending(c => c.Swag)
                .ThenBy(c => c.Id)
                .ToList();

            GeneralError(cards);

            return cards;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            var cards = this.cardsById.Values
                .Where(c => c.Type == type && c.Damage >= lo && c.Damage <= hi)
                .OrderByDescending(c => c.Damage)
                .ThenBy(c => c.Id)
                .ToList();

            GeneralError(cards);

            return cards;
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in this.cardsById.Values)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private static void GeneralError(List<BattleCard> cards)
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}