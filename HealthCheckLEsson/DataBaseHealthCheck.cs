using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace HealthCheckLEsson;

public class DataBaseHealthCheck : IHealthCheck
{
    private readonly ApplicationDbContext _context;

    public DataBaseHealthCheck(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.Health.AnyAsync();
            return HealthCheckResult.Healthy("Banco de dados está acessível e a tabela foi consultada com sucesso.");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("Falha ao acessar o banco de dados ou consultar a tabela.", ex);
        }
    }
}