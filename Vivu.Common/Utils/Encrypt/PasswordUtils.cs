using System;
using System.Security.Cryptography;
using System.Text;

public static class PasswordUtils
{
    private const int SaltSize = 16; // 128 bit 
    private const int KeySize = 32; // 256 bit
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

    // Verifies if the provided plain password matches the hashed password
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        var parts = hashedPassword.Split('.', 3);

        if (parts.Length != 3)
        {
            throw new FormatException("Invalid hash format. Expected format: {iterations}.{salt}.{hash}");
        }

        var iterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var hash = Convert.FromBase64String(parts[2]);

        var hashToCompare = HashPasswordInternal(password, salt, iterations);

        return CryptographicOperations.FixedTimeEquals(hash, hashToCompare);
    }

    // Hashes the password using the same method as when storing it
    public static string HashPassword(string password)
    {
        using var rng = new RNGCryptoServiceProvider();
        var salt = new byte[SaltSize];
        rng.GetBytes(salt);

        var hash = HashPasswordInternal(password, salt, Iterations);

        return $"{Iterations}.{Convert.ToBase64String(salt)}.{Convert.ToBase64String(hash)}";
    }

    // Internal method to hash a password with a given salt and iterations
    private static byte[] HashPasswordInternal(string password, byte[] salt, int iterations)
    {
        using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithm);
        return rfc2898DeriveBytes.GetBytes(KeySize);
    }
}