using System;
using System.Security.Cryptography;

using Aragas.Network.Extensions;

using PCLExt.FileStorage;

namespace PokeD.Core.Extensions
{
    public static class IFileExtensions
    {
        public static string MD5Hash(this IFile file)
        {
            using (var fileStream = file.OpenAsync(FileAccess.Read).Result)
            using (var md5 = MD5.Create())
                return BitConverter.ToString(md5.ComputeHash(fileStream.ReadFully())).Replace("-", "").ToLower();
        }
    }
}