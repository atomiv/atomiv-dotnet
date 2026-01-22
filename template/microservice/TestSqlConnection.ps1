# Test SQL Server Connection
$connectionString = "Server=127.0.0.1,1433;Database=master;User Id=sa;Password=YourStrong@Passw0rd;TrustServerCertificate=True;Connection Timeout=30;"

Write-Host "Testing SQL Server connection..."
try {
    $connection = New-Object System.Data.SqlClient.SqlConnection($connectionString)
    $connection.Open()
    Write-Host "SUCCESS: Connected to SQL Server!" -ForegroundColor Green
    $connection.Close()
} catch {
    Write-Host "FAILED: Could not connect to SQL Server" -ForegroundColor Red
    Write-Host $_.Exception.Message
}
