using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivu.Data.Models;
using Vivu.Data.Repository;

namespace Vivu.Data
{
    public class UnitOfWork
    {

        private VivuDiaryContext _context;
        private UserRepository _userRepository;
        private RefreshTokenRepository _refreshTokenRepository;

        public UnitOfWork()
        {
            _context ??= new VivuDiaryContext();
        }

        public UserRepository UserRepository
        {
            get
            {
                if (_userRepository != null)
                {
                    return _userRepository;
                }
                _userRepository = new UserRepository(_context);
                return _userRepository;
            }
        }

        public  RefreshTokenRepository RefreshTokenRepository
        {
            get
            {
                if (_refreshTokenRepository != null)
                {
                    return _refreshTokenRepository;
                }
                _refreshTokenRepository = new RefreshTokenRepository(_context);
                return _refreshTokenRepository;
            }
        }

    }
}
