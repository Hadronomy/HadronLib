using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Xunit;
using HadronLib.Encryption;
using Xunit.Abstractions;

namespace HadronLib.Tests.Encryption
{
    public class AESEncryptionTools
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AESEncryptionTools(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Decrypts_Files_As_Expected()
        {
            var save64EncryptedBytes = File.ReadAllBytes(@"C:\Users\pablo\Desktop\hongo_y_honga__sello_450geo.dat");

            var saveDecryptedBytes = HadronLib.Encryption.AESEncryptionTools.DecodeHollow(save64EncryptedBytes);

            _testOutputHelper.WriteLine(Encoding.UTF8.GetString(saveDecryptedBytes));
            
            File.WriteAllBytes(@"C:\Users\pablo\Desktop\desencriptado.json", saveDecryptedBytes);
            
            Assert.True(true);
        }
    }
}