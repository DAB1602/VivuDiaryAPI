using System;
using System.Collections.Generic;
using Vivu.Data.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivu.Service.Base;
using Vivu.Data;
using Vivu.Common;
using System.Drawing;

namespace Vivu.Service
{
    public interface IUserService
    {
        Task<IBusinessResult> GetAll();

        Task<IBusinessResult> GetById(int id);

        Task<IBusinessResult> Save(User point);

        Task<IBusinessResult> Delete(int id);
    }

    public class UserService : IUserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService()
        {
            unitOfWork = new UnitOfWork();
        }

        public async Task<IBusinessResult> GetAll()
        {
            var users = await unitOfWork.UserRepository.GetAllAsync();

            if (users == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<User>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, users);
            }
        }

        public async Task<IBusinessResult> GetById(int id)
        {
            var point = await unitOfWork.UserRepository.GetByIdAsync(id);

            if (point == null)
            {
                return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Point>());
            }
            else
            {
                return new BusinessResult(Const.SUCCESS_READ_CODE, Const.SUCCESS_READ_MSG, point);
            }
        }

        public async Task<IBusinessResult> Save(User user)
        {
            try
            {
                int result = -1;
                var pointTmp = await unitOfWork.UserRepository.GetByIdAsync(user.Id);

                if (pointTmp != null)
                {
                    result = await unitOfWork.UserRepository.UpdateAsync(user);

                    if (result > 0)
                    {
                        return new BusinessResult(Const.SUCCESS_UPDATE_CODE, Const.SUCCESS_UPDATE_MSG, user);
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_UPDATE_CODE, Const.FAIL_UPDATE_MSG, new List<User>());
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<User>());
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }
        }

        public async Task<IBusinessResult> Delete(int id)
        {
            try
            {

                var point = await unitOfWork.UserRepository.GetByIdAsync(id);

                if (point != null)
                {
                    var result = await unitOfWork.UserRepository.RemoveAsync(point);

                    if (result)
                    {
                        return new BusinessResult(Const.SUCCESS_DELETE_CODE, Const.SUCCESS_DELETE_MSG, new List<Point>());
                    }
                    else
                    {
                        return new BusinessResult(Const.FAIL_DELETE_CODE, Const.FAIL_DELETE_MSG, new List<Point>());
                    }
                }
                else
                {
                    return new BusinessResult(Const.WARNING_NO_DATA_CODE, Const.WARNING_NO_DATA_MSG, new List<Point>());
                }
            }
            catch (Exception ex)
            {
                return new BusinessResult(Const.ERROR_EXCEPTION, ex.Message);
            }

        }
    }
}
