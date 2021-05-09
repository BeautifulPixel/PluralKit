﻿#nullable enable
using System.Collections.Generic;

namespace PluralKit.Core
{
    /// <summary>
    /// Model for the `proxy_members` PL/pgSQL function in `functions.sql`
    /// </summary>
    public class ProxyMember
    {
        public MemberId Id { get; }
        public IReadOnlyCollection<ProxyTag> ProxyTags { get; } = new ProxyTag[0];
        public bool KeepProxy { get; }
        
        public string? ServerName { get; }
        public string? DisplayName { get; }
        public string Name { get; } = "";
        
        public string? ServerAvatar { get; }
        public string? Avatar { get; }


        public bool AllowAutoproxy { get; }
        public string? Color { get; }

        public string ProxyName(MessageContext ctx)
        {
            var tag = ctx.ServerTag ?? ctx.SystemTag;
            if (tag != null)
              return $"{ServerName ?? DisplayName ?? Name} {ctx.SystemTag}";
            else
              return ServerName ?? DisplayName ?? Name;
        }

        public string? ProxyAvatar(MessageContext ctx) => ServerAvatar ?? Avatar ?? ctx.SystemAvatar;

        public ProxyMember() { }

        public ProxyMember(string name, params ProxyTag[] tags)
        {
            Name = name;
            ProxyTags = tags;
        }
    }
}