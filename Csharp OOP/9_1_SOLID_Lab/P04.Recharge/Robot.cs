namespace P04.Recharge
{
    using System;
    public class Robot : Worker, IRechargeable
    {
        private readonly int capacity;
        private int currentPower;

        public Robot(string id, int capacity)
            : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity => this.capacity;

        public int CurrentPower
        {
            get => this.currentPower;
            private set => this.currentPower = value;
        }

        public override void Work(int hours)
        {
            if (hours > this.CurrentPower)
            {
                hours = this.CurrentPower;
            }

            base.Work(hours);
            this.currentPower -= hours;
        }

        public void Recharge()
        {
            this.currentPower = this.Capacity;
        }
    }
}