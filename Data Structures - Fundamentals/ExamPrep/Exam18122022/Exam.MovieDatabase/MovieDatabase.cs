using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MovieDatabase
{
    public class MovieDatabase : IMovieDatabase
    {
        private readonly Dictionary<string, Actor> actors = new Dictionary<string, Actor>();
        private readonly Dictionary<string, Movie> movies = new Dictionary<string, Movie>();
        private readonly Dictionary<Actor, List<Movie>> actorMovies = new Dictionary<Actor, List<Movie>>();

        public void AddActor(Actor actor)
        {
            if (this.Contains(actor))
            {
                throw new ArgumentException();
            }
            
            this.actors.Add(actor.Id, actor);
            this.actorMovies.Add(actor, new List<Movie>());
        }

        public void AddMovie(Actor actor, Movie movie)
        {
            if (!this.Contains(actor))
            {
                throw new ArgumentException();
            }

            this.movies.Add(movie.Id, movie);
            this.actorMovies[actor].Add(movie);
        }

        public bool Contains(Actor actor)
            => this.actors.ContainsKey(actor.Id);

        public bool Contains(Movie movie)
            => this.movies.ContainsKey(movie.Id);

        public IEnumerable<Actor> GetActorsOrderedByMaxMovieBudgetThenByMoviesCount()
            => this.actorMovies
                .OrderByDescending(a => a.Value
                    .Max(m => m.Budget))
                .ThenByDescending(a => a.Value.Count)
                .Select(a => a.Key);


        public IEnumerable<Movie> GetAllMovies()
            => this.movies.Values;

        public IEnumerable<Movie> GetMoviesInRangeOfBudget(double lower, double upper)
            => this.movies.Values
                .Where(m => m.Budget >= lower && m.Budget <= upper)
                .OrderByDescending(m => m.Rating);

        public IEnumerable<Movie> GetMoviesOrderedByBudgetThenByRating()
            => this.movies.Values
                .OrderByDescending(m => m.Budget)
                .ThenByDescending(m => m.Rating);

        public IEnumerable<Actor> GetNewbieActors()
            => this.actorMovies
                .Where(a => !a.Value.Any())
                .Select(a => a.Key);
    }
}
