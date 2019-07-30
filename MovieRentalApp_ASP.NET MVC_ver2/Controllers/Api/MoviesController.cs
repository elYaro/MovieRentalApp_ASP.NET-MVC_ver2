﻿using AutoMapper;
using MovieRentalApp_ASP.NET_MVC_ver2.Dtos;
using MovieRentalApp_ASP.NET_MVC_ver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieRentalApp_ASP.NET_MVC_ver2.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private MyDbContext _context;

        public MoviesController()
        {
            _context = new MyDbContext();
        }
        
        //GET/api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }


        //GET/api/movies/1
        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Movie, MovieDto>(movie);
        }

        //POST/api/movies
        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return movieDto;
        }

        //PUT/api/movies/1
        [HttpPut]
        public void UpdateMovie (int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb); 
            
            _context.SaveChanges();
        }



        //DELETE/api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
