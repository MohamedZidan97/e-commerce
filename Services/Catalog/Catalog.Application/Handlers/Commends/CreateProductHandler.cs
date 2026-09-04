using AutoMapper;
using Catalog.Application.Commends;
using Catalog.Application.Responses;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commends
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponseDto>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public CreateProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }
        public async Task<ProductResponseDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = mapper.Map<Product>(request);

            var newProduct = await productRepository.CreateProduct(productEntity);

            var res = mapper.Map<ProductResponseDto>(newProduct);

            return res;
        }
    }
}
