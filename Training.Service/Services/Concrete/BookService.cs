using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.UnitOfWork;
using Training.Entity.Entities;
using Training.Service.Services.Abstract;

namespace Training.Service.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Book>> ListAllBooksAsync()
        {
            return await _unitOfWork.Books.GetAllAsync();

        }
    }
}
