using AutoMapper;
using Common.Dtos;
using Common.StaticClasses;
using Customerize.Core.DTOs.Category;
using Customerize.Core.Repositories;
using Customerize.Core.Services;
using Customerize.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Customerize.Service.Mapping.MapProfile;

namespace Customerize.Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResultDto<T>> AddAsync(T entity)
        {

            await _repository.AddAsync(entity);

            var success = await _unitOfWork.CommitAsync();
            if (success)
            {
                return new ResultDto<T>()
                {
                    Data = entity,
                    IsSuccess = true,
                    Message = ResultMessages.GeneralAddedMessage
                };
            }
            else
            {
                return new ResultDto<T>()
                {
                    Data = entity,
                    IsSuccess = false,
                    Message = ResultMessages.GeneralErrorMessage
                };
            }
            //ToDo:ExceptionHandling

        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<ResultDto<IEnumerable<T>>> GetAllAsync()
        {

            var entities = await _repository.GetAll().ToListAsync();
            if (entities == null)
            {
                return new ResultDto<IEnumerable<T>>()
                {
                    IsSuccess = false,
                    Message = ResultMessages.GeneralErrorMessage
                };
            }
            else
            {
                return new ResultDto<IEnumerable<T>>()
                {
                    Data = entities,
                    IsSuccess = true,
                    Message = ResultMessages.GeneralSuccess
                };
            }

        }

        public async Task<ResultDto<T>> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new ResultDto<T>()
                {
                    IsSuccess = false,
                    Message = ResultMessages.GeneralErrorMessage
                };
            }
            else
            {
                return new ResultDto<T>()
                {
                    Data = entity,
                    IsSuccess = true,
                    Message = ResultMessages.GeneralSuccess
                };
            }
        }

        public async Task<ResultDto<T>> RemoveAsync(T entity)
        {

            if (entity != null)
            {
                _repository.Remove(entity);
                var success = await _unitOfWork.CommitAsync();
                if (success)
                {
                    return new ResultDto<T>()
                    {
                        IsSuccess = true,
                        Message = ResultMessages.GeneralRemoveMessage
                    };
                }
                else
                {
                    return new ResultDto<T>()
                    {
                        IsSuccess = false,
                        Message = ResultMessages.GeneralErrorMessage
                    };
                }
            }
            return new ResultDto<T>()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage
            };

        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ResultDto<T>> UpdateAsync(T entity)
        {
            if (entity != null)
            {
                _repository.Update(entity);
                var success = await _unitOfWork.CommitAsync();
                return new ResultDto<T>()
                {
                    Data = entity,
                    IsSuccess = true,
                    Message = ResultMessages.GeneralSuccess
                };
            }
            return new ResultDto<T>()
            {
                IsSuccess = false,
                Message = ResultMessages.GeneralErrorMessage
            };
        }

        public async Task<IQueryable<T>> Where(Expression<Func<T, bool>> expression)
        {
            return _repository.Where(expression).AsNoTracking();
        }

        public async Task<List<T>> WhereList(Expression<Func<T, bool>> expression)
        {
            return await _repository.Where(expression).ToListAsync();
        }
    }
}
