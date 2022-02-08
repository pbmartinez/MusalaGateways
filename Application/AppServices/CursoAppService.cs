﻿using Application.Dtos;
using Application.IAppServices;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Domain.IRepositories;
using Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.AppServices
{
    public partial class CursoAppService : ICursoAppService
    {
        private readonly IMapper _mapper;
        private readonly ICursoRepository _CursoRepository;

        public CursoAppService(IMapper mapper, ICursoRepository CursoRepository)
        {
            _mapper = mapper;
            _CursoRepository = CursoRepository;
        }

        public async Task<bool> AddAsync(CursoDtoForCreate item)
        {
            await _CursoRepository.AddAsync(_mapper.Map<Domain.Entities.Curso>(item));
            var commited = await _CursoRepository.UnitOfWork.CommitAsync();
            return commited > 0;
        }

        public async Task< IEnumerable<CursoDto>> FindWithSpecificationPatternAsync(Specification<CursoDto> specification = null, List<Expression<Func<CursoDto, object>>> Includes = null)
        {
            var domainExpressionList = Includes == null
                ? new List<Expression<Func<Domain.Entities.Curso, object>>>()
                : _mapper.MapIncludesList<Expression<Func<Domain.Entities.Curso, object>>>(Includes).ToList();
            return _mapper.Map<List<CursoDto>>(
                await _CursoRepository.FindWithExpressionAsync(
                    _mapper.MapExpression<Expression<Func<Domain.Entities.Curso, bool>>>(
                        specification == null ? a => true : specification.ToExpression()), domainExpressionList));
        }

        public async Task<List<CursoDto>> GetAllAsync(List<Expression<Func<CursoDto, object>>> Includes = null)
        {
            var domainExpressionList = Includes == null
                ? new List<Expression<Func<Domain.Entities.Curso, object>>>()
                : _mapper.MapIncludesList<Expression<Func<Domain.Entities.Curso, object>>>(Includes).ToList();
            var items = await _CursoRepository.GetAllAsync(domainExpressionList);
            var dtoItems = _mapper.Map<List<CursoDto>>(items.ToList());
            return dtoItems;
        }


        public async Task<CursoDto> GetAsync(Guid id, List<Expression<Func<CursoDto, object>>> Includes = null)
        {
            var domainExpressionList = Includes == null
                ? new List<Expression<Func<Domain.Entities.Curso, object>>>()
                : _mapper.MapIncludesList<Expression<Func<Domain.Entities.Curso, object>>>(Includes).ToList();
            return _mapper.Map<CursoDto>(await _CursoRepository.GetAsync(id, domainExpressionList));
        }

        public async Task<CursoDtoForUpdate> GetForUpdateAsync(Guid id, List<Expression<Func<CursoDto, object>>> Includes = null)
        {
            var domainExpressionList = Includes == null
                ? new List<Expression<Func<Domain.Entities.Curso, object>>>()
                : _mapper.MapIncludesList<Expression<Func<Domain.Entities.Curso, object>>>(Includes).ToList();
            return _mapper.Map<CursoDtoForUpdate>(await _CursoRepository.GetAsync(id, domainExpressionList));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var item = await _CursoRepository.GetAsync(id);
            await _CursoRepository.DeleteAsync(item);
            var commited = await _CursoRepository.UnitOfWork.CommitAsync();

            return commited > 0;
        }

        public async Task<bool> UpdateAsync(CursoDtoForUpdate item)
        {
            await _CursoRepository.UpdateAsync(_mapper.Map<Domain.Entities.Curso>(item));
            var commited = await _CursoRepository.UnitOfWork.CommitAsync();
            return commited > 0;
        }
    }
}
