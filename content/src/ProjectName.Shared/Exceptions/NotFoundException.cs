// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ProjectName.Shared.Exceptions
{
    public class NotFoundException : DomainException
    {
        public NotFoundException()
            : base("NotFound")
        {
        }
    }
}
