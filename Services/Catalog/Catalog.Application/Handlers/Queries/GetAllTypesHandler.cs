using AutoMapper;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Queries
{
    public class GetAllTypesHandler : IRequestHandler<GetAllTypesQuery, IList<TypeResponseDto>>
    {
        private readonly IMapper mapper;
        private readonly ITypeRepository typeRepository;

        public GetAllTypesHandler(IMapper mapper, ITypeRepository  typeRepository)
        {
            this.mapper = mapper;
            this.typeRepository = typeRepository;
        }

        public async Task<IList<TypeResponseDto>> Handle(GetAllTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await typeRepository.GetAllProductTypes();
            var typesMapper = mapper.Map<IList<ProductType>, IList<TypeResponseDto>>(types.ToList());

            return typesMapper;


        }
    }
}
