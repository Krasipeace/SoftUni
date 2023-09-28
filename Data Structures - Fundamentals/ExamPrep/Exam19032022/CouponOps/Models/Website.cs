namespace CouponOps.Models
{
    using System.Collections.Generic;

    public class Website
    {
        public Website(string domain, int usersCount)
        {
            this.Domain = domain;
            this.UsersCount = usersCount;
            this.Coupons = new HashSet<Coupon>();
        }

        public string Domain { get; set; }
        public int UsersCount { get; set; }
        public HashSet<Coupon> Coupons { get; set; }
    }
}
