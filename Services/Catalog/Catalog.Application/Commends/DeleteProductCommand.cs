using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Commends
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }
}
