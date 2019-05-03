﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application.UseCases
{
    public abstract class BaseCommand<TRequest, TResponse> : ICommand<TRequest, TResponse>
    {
        public TRequest Request { get; set; }
    }
}
