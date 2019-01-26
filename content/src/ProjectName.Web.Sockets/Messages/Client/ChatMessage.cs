// Copyright (c) ProjectName. All rights reserved.
// Licensed under the BSD license. See LICENSE file in the project root for full license information.

using System.ComponentModel.DataAnnotations;

namespace ProjectName.Web.Sockets.Messages.Client
{
    public class ChatMessage : Abstract.IMessage
    {
        [Required]
        [MaxLength(249)]
        public string Message { get; set; }
    }
}
