using Prism.Mvvm;
using System;

namespace LazyRaid.Models
{
    public class BindableReferenceBase : BindableBase
    {
        public Guid ID { get; set; } = Guid.NewGuid();
    }
}
