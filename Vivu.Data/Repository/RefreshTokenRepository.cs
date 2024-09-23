using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivu.Data.Base;
using Vivu.Data.Models;
using Vivu.Common.Utils;

namespace Vivu.Data.Repository
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>
    {
        public RefreshTokenRepository() { }

        public RefreshTokenRepository(VivuDiaryContext context) : base(context) { }

    }
}
