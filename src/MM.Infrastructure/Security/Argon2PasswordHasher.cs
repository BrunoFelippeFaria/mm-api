using System.Security.Cryptography;
using System.Text;

using Konscious.Security.Cryptography;

using MM.Domain.Shared.Interfaces;

namespace MM.Infrastructure.Security;

public class Argon2PasswordHasher : IPasswordHasher
{
    private readonly int _salt_size = 16;
    private readonly int _hash_size = 32;

    public string Hash(string password)
    {
        byte[] salt = GenerateSalt(_salt_size);
        var hash = GenerateHash(password, salt);

        byte[] combined = new byte[salt.Length + hash.Length];
        Buffer.BlockCopy(salt, 0, combined, 0, salt.Length);
        Buffer.BlockCopy(hash, 0, combined, salt.Length, hash.Length);

        return Convert.ToBase64String(combined);
    }

    public bool Verify(string password, string hash)
    {
        byte[] combined = Convert.FromBase64String(hash);
        byte[] salt = new byte[_salt_size];
        byte[] expectedHash = new byte[_hash_size];

        Buffer.BlockCopy(combined, 0, salt, 0, 16);
        Buffer.BlockCopy(combined, 16, expectedHash, 0, 32);

        byte[] actualHash = GenerateHash(password, salt);

        return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
    }

    private static byte[] GenerateSalt(int length)
    {
        return RandomNumberGenerator.GetBytes(length);
    }

    private byte[] GenerateHash(string password, byte[] salt)
    {
        using var hasher = new Argon2id(Encoding.UTF8.GetBytes(password));

        hasher.Salt = salt;
        hasher.DegreeOfParallelism = 8;
        hasher.MemorySize = 65536;
        hasher.Iterations = 4;
        return hasher.GetBytes(_hash_size);
    }

}