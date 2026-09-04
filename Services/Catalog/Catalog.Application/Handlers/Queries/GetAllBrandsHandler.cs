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
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IList<BrandResponseDto>>
    {
        private readonly IMapper mapper;
        private readonly IBrandRepository brandRepository;

        public GetAllBrandsHandler(IMapper mapper,  IBrandRepository brandRepository)
        {
            this.mapper = mapper;
            this.brandRepository = brandRepository;
        }


        public async Task<IList<BrandResponseDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await brandRepository.GetAllProductBrand();
            var brandsMapper =  mapper.Map<IList<ProductBrand>,IList<BrandResponseDto>>(brands.ToList());

            return brandsMapper;
        }
    }
}
