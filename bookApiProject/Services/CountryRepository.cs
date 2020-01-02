using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApiProject.Models;

namespace bookApiProject.Services
{
    public class CountryRepository : ICountryRepository
    {
        private BookDBContext _countryContext;
        // BookDbContext here represents my database logic object
        // my access to the database tables and records

        public CountryRepository(BookDBContext countryContext)
        {
            _countryContext = countryContext; // dependency injection
        }

        public bool CountryExists(int countryId)
        {
            return _countryContext.Countries.Any(c => c.Id == countryId);
        }

        public ICollection<Author> GetAuthorsFromCountry(int countryId)
        {
            return _countryContext.Authors.Where(c => c.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _countryContext.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _countryContext.Countries.Where(c => c.Id == countryId).FirstOrDefault();
            // first or default means it will return the first record found or default = null

        }

        public Country GetCountryOfAuthor(int authorId)
        {
            return _countryContext.Authors.Where(a => a.Id == authorId)
                .Select(c => c.Country).FirstOrDefault();
            // we first get the author id where author id is equal
            // the select country of gotten author id
        }

        public bool IsDuplicateCountryName(int countryId, string countryName)
        {
            var country = _countryContext.Countries.Where(
               c => c.Name.Trim().ToUpper() == countryName.Trim().ToUpper() 
               && c.Id != countryId
             ).FirstOrDefault();

            return country == null ? false : true;
        }
    }
}
