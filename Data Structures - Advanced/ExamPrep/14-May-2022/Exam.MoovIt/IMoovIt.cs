using System.Collections.Generic;

namespace Exam.MoovIt
{
    public interface IMoovIt
    {
        void AddRoute(Route route);

        void RemoveRoute(string routeId);

        bool Contains(Route route);

        int Count { get; }

        Route GetRoute(string routeId);

        void ChooseRoute(string routeId);

        IEnumerable<Route> SearchRoutes(string startPoint, string endPoint);

        IEnumerable<Route> GetFavoriteRoutes(string destinationPoint);

        IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints();
    }
}
