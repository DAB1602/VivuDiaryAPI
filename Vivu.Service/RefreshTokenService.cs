using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivu.Data;
using Vivu.Service.Base;

namespace Vivu.Service
{
    public interface IRefreshTokenService
    {
        Task<IBusinessResult> RefreshToken(string refreshToken);
        Task<IBusinessResult> CreateToken(int userId);
    }
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly int tokenLifeTimeInMinutes;
        private readonly string _jwtSecret;

        public RefreshTokenService(int tokenLifeTimeInMinutes, string _jwtSecret)
        {

        }

        public async Task<IBusinessResult> RefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<IBusinessResult> CreateToken(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
