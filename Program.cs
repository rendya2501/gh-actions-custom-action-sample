string result = "Hello from repository B!";

// GitHub Actions の output に値を設定
string githubOutput = Environment.GetEnvironmentVariable("GITHUB_OUTPUT");
if (!string.IsNullOrEmpty(githubOutput))
{
    using (StreamWriter writer = new StreamWriter(githubOutput, true))
    {
        writer.WriteLine($"csharp_result ={result} : {args[0]}");
    }
}

Console.WriteLine($"Set output value: {result}");