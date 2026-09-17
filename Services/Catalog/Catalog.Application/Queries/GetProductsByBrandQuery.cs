using Catalog.Application.Responses;
using MediatR;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Queries
{
    public class GetProductsByBrandQuery : IRequest<IList<ProductResponseDto>>
    {
        public string? BrandId { get; set; }
        public string? BrandName { get; set; }

        public GetProductsByBrandQuery(string? brandId , string? brandName)
        {
           this.BrandId = brandId;
            this.BrandName = brandName;
        }

    }
}
