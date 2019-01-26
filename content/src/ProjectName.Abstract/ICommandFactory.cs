// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ProjectName.Abstract
{
    public interface ICommandFactory
    {
        System.Threading.Tasks.Task Execute<T>(T command)
            where T : class, ICommand;
    }
}
