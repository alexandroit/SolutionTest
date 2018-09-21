using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Soluction.Domain.Entites
{
    public abstract class BaseEntitie : Notifiable
    {
        public BaseEntitie()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
