// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

namespace ProjectName.Web.Sockets.Messages
{
    public class ServerMessage<T>
        where T : Abstract.IMessage
    {
        public string Type { get; set; }

        public ErrorInfo Error { get; set; }

        public T Payload { get; set; }
    }
}
