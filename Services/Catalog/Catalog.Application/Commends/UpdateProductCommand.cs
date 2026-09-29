using Catalog.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commends
{
    public class UpdateProductCommand : IRequest<bool>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string ImageFile { get; set; }
        //  [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public decimal Price { get; set; }
    }
}
