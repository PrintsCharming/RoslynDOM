﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynDom.Common
{
   public interface IAccessor :
              IMisc,
              IStatementContainer,
              IHasAttributes,
              IHasAccessModifier,
              IDom<IAccessor>,
              IHasName
   {
      AccessorType AccessorType { get; }
   }
}
