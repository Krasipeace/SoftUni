namespace CouponOps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CouponOps.Models;

    using Interfaces;

    public class CouponOperations : ICouponOperations
    {
        private readonly Dictionary<string, Website> websites;
        private readonly Dictionary<string, Coupon> coupons;

        public CouponOperations()
        {
            this.websites = new Dictionary<string, Website>();
            this.coupons = new Dictionary<string, Coupon>();
        }

        public void AddCoupon(Website website, Coupon coupon)
        {
            if (!this.Exist(website))
            {
                throw new ArgumentException();
            }

            this.coupons.Add(coupon.Code, coupon);
            this.websites[website.Domain].Coupons.Add(coupon);
            coupon.Website = website;
        }

        public bool Exist(Website website)
            => this.websites.ContainsKey(website.Domain);

        public bool Exist(Coupon coupon)
            => this.coupons.ContainsKey(coupon.Code);

        public IEnumerable<Coupon> GetCouponsForWebsite(Website website)
        {
            if (!this.Exist(website))
            {
                throw new ArgumentException();
            }

            return this.coupons.Values
                .Where(c => c.Website.Domain == website.Domain);
        }

        public IEnumerable<Coupon> GetCouponsOrderedByValidityDescAndDiscountPercentageDesc()
            => this.coupons.Values
                .OrderByDescending(c => c.Validity)
                .ThenByDescending(c => c.DiscountPercentage);

        public IEnumerable<Website> GetSites()
            => this.websites.Values;

        public IEnumerable<Website> GetWebsitesOrderedByUserCountAndCouponsCountDesc()
            => this.websites.Values
                .OrderByDescending(w => w.UsersCount)
                .ThenByDescending(w => w.Coupons.Count);

        public void RegisterSite(Website website)
        {
            if (this.Exist(website))
            {
                throw new ArgumentException();
            }

            this.websites.Add(website.Domain, website);
        }

        public Coupon RemoveCoupon(string code)
        {
            var coupon = this.coupons[code];
            if (coupon == null)
            {
                throw new ArgumentException();
            }

            websites[coupon.Website.Domain].Coupons
                .Remove(coupon);
            coupon.Website = null;
            coupons.Remove(code);

            return coupon;
        }

        public Website RemoveWebsite(string domain)
        {
            this.websites[domain].Coupons
                .ForEach(c => this.coupons.Remove(c.Code));

            return this.websites[domain];
        }

        public void UseCoupon(Website website, Coupon coupon)
        {
            if (!this.Exist(website) 
                || !this.Exist(coupon)
                || !website.Coupons.Contains(coupon))
            {
                throw new ArgumentException();
            }

            websites[website.Domain].Coupons
                .Remove(coupon);
            coupon.Website = null;
            coupons.Remove(coupon.Code);
        }
    }
}
