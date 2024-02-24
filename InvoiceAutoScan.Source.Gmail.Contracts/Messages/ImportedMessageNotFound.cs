using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceAutoScan.Source.Gmail.Contracts.Messages
{
    public record ImportedMessageNotFound
    {
        public Guid? Id { get; init; }

        public string? SourceId { get; init; }

        public string Message => "TODO";
    }
}
