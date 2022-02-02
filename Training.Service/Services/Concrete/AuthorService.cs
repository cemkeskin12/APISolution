using Training.Data.UnitOfWork;
using Training.Entity.Entities;
using Training.Service.Services.Abstract;

namespace Training.Service.Services.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IList<Author>> ListAllAuthorsAsync()
        {
            return await _unitOfWork.Author.GetAllAsync();
        }
    }
}
