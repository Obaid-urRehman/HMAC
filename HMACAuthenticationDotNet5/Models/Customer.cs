using System;
using System.Collections.Generic;

#nullable disable

namespace HMACAuthenticationDotNet5.Models
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IdentificationNo { get; set; }
    }
}
