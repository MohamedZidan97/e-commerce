using AutoMapper;
using Catalog.Application.Commends;
using Catalog.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Handlers.Commends
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>

    {
        private readonly IMapper mapper;
        private readonly IProductRepository productRepository;

        public DeleteProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var res = await productRepository.DeleteProduct(request.Id);

            return res;

        }
    }
}
