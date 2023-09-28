namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CouponOps.Models;

    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private readonly Dictionary<Website, HashSet<Coupon>> websites;
        private readonly HashSet<Coupon> coupons;

        public CouponOperations()
        {
            this.coupons = new HashSet<Coupon>();
            this.websites = new Dictionary<Website, HashSet<Coupon>>();
        }

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!this.Exist(website))
            {
                throw new ArgumentException();
            }

            if (this.Exist(coupon))
            {
                throw new ArgumentException();
            }

            this.websites[website].Add(coupon);
            this.coupons.Add(coupon);
            coupon.Website = website;
        }

        public bool Exist(Website website)
            => this.websites.ContainsKey(website);

        public bool Exist(Coupon coupon)
            => this.coupons.Contains(coupon);

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
            => !this.Exist(website) 
                ? throw new ArgumentException() 
                : (IEnumerable<Coupon>)this.websites[website];

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
            => this.coupons
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage);

        public IEnumerable<Website> GetSites()
            => this.websites.Keys;

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
            => this.websites
                .OrderBy(w => w.Key.UsersCount)
                .ThenByDescending(w => w.Value.Count)
                .Select(w => w.Key);

        public void RegisterSite(Website website)
        {
            if (this.Exist(website))
            {
                throw new ArgumentException();
            }

            this.websites.Add(website, new HashSet<Coupon>());
        }

        public Website RemoveWebsite(string domain)
        {
            Website toRemove = this.websites.Keys
                .FirstOrDefault(w => w.Domain == domain) 
                ?? throw new ArgumentException();

            foreach (var coupon in this.websites[toRemove])
            {
                coupon.Website = null;
                this.coupons.Remove(coupon);
            }

            this.websites.Remove(toRemove);
            return toRemove;
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this.Exist(website)
                || !this.Exist(coupon)
                || !this.websites[website].Contains(coupon))
            {
                throw new ArgumentException();
            }

            this.websites[website].Remove(coupon);
            coupon.Website = null;
            this.coupons.Remove(coupon);
        }

        public Coupon RemoveCoupon(string code)
        {
            var removeCoupon = this.coupons
                .FirstOrDefault(c => c.Code == code) 
                ?? throw new ArgumentException();

            this.websites[removeCoupon.Website].Remove(removeCoupon);
            removeCoupon.Website = null;
            this.coupons.Remove(removeCoupon);

            return removeCoupon;
        }
    }
}
