using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ApplicationCore.Models.Response;
using System.Linq.Expressions;

namespace MovieShop.UnitTests
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private MovieService _sut;
        private List<Movie> _fakeMovies;
        private readonly Mock<IMovieRepository> _mockMovieRepository;
        private readonly Mock<ICastRepository> _mockICastRepository;
        private readonly Mock<IGenreRepository> _mockGenreRepository;
        private readonly Mock<IPurchaseRepository> _mockPuchaseRepository;

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockICastRepository = new Mock<ICastRepository>();
            _mockGenreRepository = new Mock<IGenreRepository>();
            _mockPuchaseRepository = new Mock<IPurchaseRepository>();
            //_sut = new MovieService(_mockMovieRepository.Object, _mockICastRepository.Object, _mockGenreRepository.Object, _mockPuchaseRepository.Object);

        }


        [TestInitialize]
        public void TestInitialize()
        {
            _fakeMovies = new List<Movie>
            {
                new Movie
                {
                    Id = 1,
                    Title = "Test 1",
                    Budget = 11000,
                },
                new Movie
                {
                    Id = 2,
                    Title = "Test 2",
                    Budget = 12000,
                },
                new Movie
                {
                    Id = 3,
                    Title = "Test 3",
                    Budget = 13000,
                }
            };
            _mockMovieRepository.Setup(m => m.GetTop30HighestRevenueMovies()).ReturnsAsync(_fakeMovies);
            _mockMovieRepository.Setup(m => m.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int m) => _fakeMovies.First(x => x.Id == m));
        }

        [TestMethod]
        public async Task Test_For_TopRevenueMovies_From_FakeDataAsync()
        {
            _sut = new MovieService(_mockMovieRepository.Object, _mockICastRepository.Object, _mockGenreRepository.Object, _mockPuchaseRepository.Object);
            var movies = await _sut.GetTop30RevenueMovie();
            // assert
            Assert.IsNotNull(movies);
            Assert.AreEqual(3, movies.Count());
            CollectionAssert.AllItemsAreInstancesOfType(movies, typeof(MovieCardResponseModel));
        }
    }

    //public class FakeMovieRepository : IMovieRepository
    //{
    //    private List<Movie> _fakeMovies;
    //    public Task<Movie> AddAsync(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task DeleteAsync(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Movie> GetByIdAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<int> GetCountAsync(Expression<Func<Movie, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> GetExistsAsync(Expression<Func<Movie, bool>> filter = null)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Review>> GetMoviesReviewsAsync(int id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Movie>> GetTop30HighestRatedMovies()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Movie>> GetTop30HighestRevenueMovies()
    //    {
    //        _fakeMovies = new List<Movie>
    //        {
    //            new Movie
    //            {
    //                Id = 1,
    //                Title = "Test 1",
    //                Budget = 11000,
    //            },
    //            new Movie
    //            {
    //                Id = 2,
    //                Title = "Test 2",
    //                Budget = 12000,
    //            },
    //            new Movie
    //            {
    //                Id = 3,
    //                Title = "Test 3",
    //                Budget = 13000,
    //            }
    //        };
    //        return (Task<IEnumerable<Movie>>)(IEnumerable<Movie>)_fakeMovies;
    //    }

    //    public Task<IEnumerable<Movie>> ListAllAsync()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<Movie>> ListAsync(Expression<Func<Movie, bool>> filter)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<Movie> UpdateAsync(Movie entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
