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
    public class GetProductsByBrandHandler : IRequestHandler<GetProductsByBrandQuery, IList<ProductResponseDto>>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public GetProductsByBrandHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<IList<ProductResponseDto>> Handle(GetProductsByBrandQuery request, CancellationToken cancellationToken)
        {
            var products = productRepository.GetProductsByBrand(request.BrandId,request.BrandName);

            var productsMapper= mapper.Map<IList<ProductResponseDto>>(products);


            return productsMapper;
        }
    }
    }
