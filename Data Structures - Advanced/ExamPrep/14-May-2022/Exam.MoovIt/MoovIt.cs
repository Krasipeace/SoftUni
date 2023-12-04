using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {
        private Dictionary<string, Route> routes;

        public MoovIt()
        {
            this.routes = new Dictionary<string, Route>();
        }

        public int Count 
            => this.routes.Count;

        public bool Contains(Route route)
            => this.routes.ContainsKey(route.Id);

        public void AddRoute(Route route)
        {
            if (this.Contains(route))
            {
                throw new ArgumentException();
            }

            this.routes.Add(route.Id, route);
        }

        public void RemoveRoute(string routeId)
        {
            if (!this.routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            this.routes.Remove(routeId);
        }

        public Route GetRoute(string routeId)
        {
            if (!this.routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            return this.routes[routeId];
        }

        public void ChooseRoute(string routeId)
        {
            if (!this.routes.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }

            this.routes[routeId].Popularity++;
        }

        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
            => this.routes.Values
                .Where(r => r.LocationPoints.Contains(startPoint) && r.LocationPoints.Contains(endPoint))
                .OrderBy(r => Math.Abs(r.LocationPoints.IndexOf(startPoint) - r.LocationPoints.IndexOf(endPoint)))
                .ThenByDescending(r => r.Popularity)
                .ToList();

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
            => this.routes.Values
                .Where(r => r.LocationPoints.Contains(destinationPoint) && r.LocationPoints[0] != destinationPoint)
                .OrderBy(r => r.Distance)
                .ThenByDescending(r => r.Popularity)
                .ToList();

        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
            => this.routes.Values
                .OrderByDescending(r => r.Popularity)
                .ThenBy(r => r.Distance)
                .ThenBy(r => r.LocationPoints.Count)
                .Take(5)
                .ToList();
    }
}
