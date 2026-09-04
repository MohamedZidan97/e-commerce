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
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IList<ProductResponseDto>>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public GetAllProductsHandler(IMapper mapper,  IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public async Task<IList<ProductResponseDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await productRepository.GetAllProducts();
            var productsMapper = mapper.Map<IList<Product>, IList<ProductResponseDto>>(products.ToList());

            return productsMapper;
        }
    }
}
