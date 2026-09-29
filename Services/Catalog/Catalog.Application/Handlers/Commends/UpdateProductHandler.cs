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
    //                                                request , response
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public UpdateProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Product>(request);

            var res = await productRepository.UpdateProduct(entity);

            return res;

        }
    }
}
