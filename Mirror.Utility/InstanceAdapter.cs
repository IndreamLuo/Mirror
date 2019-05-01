using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mirror.Utility
{
    public static class InstanceAdapter
    {
        public static void AdaptTo<TFrom, TTo>(this TFrom from, ref TTo to)
        {
            var refTo = to;

            var getFromMembers = StaticCache.GetCacheOrInstance(from.GetType().Name,
                () => from
                    .GetType()
                    .GetMembers(BindingFlags.SetProperty | BindingFlags.SetField | BindingFlags.Public)
                    .ToDictionary(memberInfo => memberInfo.Name));

            var setToMembers = StaticCache.GetCacheOrInstance(refTo.GetType().Name,
                () => refTo
                    .GetType()
                    .GetMembers(BindingFlags.SetProperty | BindingFlags.SetField | BindingFlags.Public)
                    .ToDictionary(memberInfo => memberInfo.Name));
                    
            MemberInfo toMember;
            foreach (var member in getFromMembers)
            {
                if (setToMembers.TryGetValue(member.Key, out toMember))
                {
                    dynamic value = member.Value.MemberType == MemberTypes.Property
                        ? (member.Value as PropertyInfo).GetValue(from)
                        : (member.Value as FieldInfo).GetValue(from);

                    if (toMember.MemberType == MemberTypes.Field)
                    {
                        (toMember as FieldInfo).SetValue(refTo, value);
                    }
                    else
                    {
                        (toMember as PropertyInfo).SetValue(refTo, value);
                    }
                }
            }
        }
    }
}