namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FitGym : IGym
    {
        private Dictionary<int, Member> membersById;
        private Dictionary<int, Trainer> trainersById;

        public FitGym()
        {
            this.membersById = new Dictionary<int, Member>();
            this.trainersById = new Dictionary<int, Trainer>();
        }

        public bool Contains(Member member)
            => this.membersById.ContainsKey(member.Id);

        public bool Contains(Trainer trainer)
            => this.trainersById.ContainsKey(trainer.Id);

        public int MemberCount
            => this.membersById.Count;

        public int TrainerCount
            => this.trainersById.Count;

        public void AddMember(Member member)
        {
            if (this.membersById.ContainsKey(member.Id))
            {
                throw new ArgumentException();
            }

            this.membersById.Add(member.Id, member);
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.trainersById.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }

            this.trainersById.Add(trainer.Id, trainer);
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.membersById.ContainsKey(member.Id))
            {
                this.membersById.Add(member.Id, member);
            }

            if (!trainersById.ContainsKey(trainer.Id) || member.Trainer != null)
            {
                throw new ArgumentException();
            }

            member.Trainer = trainer;
            this.membersById[member.Id].Trainer = trainer;
        }

        public Trainer FireTrainer(int id)
        {
            if (!this.trainersById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            var trainerToRemove = this.trainersById[id];

            this.trainersById.Remove(id);

            return trainerToRemove;
        }

        public Member RemoveMember(int id)
        {
            if (!this.membersById.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            var memberToRemove = this.membersById[id];

            this.membersById.Remove(id);

            return memberToRemove;
        }

        public IEnumerable<Member>
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
            => this.membersById.Values
                .OrderBy(m => m.RegistrationDate)
                .ThenByDescending(m => m.Name)
                .ToList();

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
            => this.trainersById.Values
                .OrderBy(t => t.Popularity)
                .ThenBy(t => t.Name)
                .ToList();

        public IEnumerable<Member> GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
            => this.membersById.Values
                .Where(m => m.Trainer == trainer)
                .OrderBy(m => m.RegistrationDate)
                .ThenBy(m => m.Name)
                .ToList();

        public IEnumerable<Member>
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
            => this.membersById.Values
                .Where(m => m.Trainer.Popularity >= lo && m.Trainer.Popularity <= hi)
                .OrderBy(m => m.Visits)
                .ThenBy(m => m.Name)
                .ToList();

        public Dictionary<Trainer, HashSet<Member>> GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            var trainerMembers = this.membersById.Values
                .GroupBy(m => m.Trainer)
                .ToDictionary(t => t.Key, m => new HashSet<Member>(m));

            var orderedTrainers = this.trainersById.Values
                .OrderBy(t => t.Members.Count)
                .ThenBy(t => t.Popularity);

            var result = new Dictionary<Trainer, HashSet<Member>>();

            foreach (var trainer in orderedTrainers)
            {
                result.Add(trainer, trainerMembers[trainer]);
            }

            return result;

            //var orderedTrainers = this.trainersById.Values
            //    .OrderBy(t => t.Members.Count)
            //    .ThenBy(t => t.Popularity);

            //var result = new Dictionary<Trainer, HashSet<Member>>();

            //foreach (var trainer in orderedTrainers)
            //{
            //    result.Add(trainer, new HashSet<Member>(this.membersById.Values
            //        .Where(m => m.Trainer == trainer)
            //        .ToList()));
            //}

            //return result;
        }
    }
}