
using Project.Data;
using System.Threading.Tasks;   //Funda okuningi kwi(documentation) link below
                                //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-9.0&tabs=visual-studio
public class UserCleanupService : BackgroundService//Silethelwa  ngu asp.net lenza what ever ofuna liyenze behind seen 
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<UserCleanupService> _logger;
    private readonly TimeSpan _checkInterval = TimeSpan.FromMinutes(1);//

    public UserCleanupService(IServiceProvider serviceProvider, ILogger<UserCleanupService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("[UserCleanupService] Starting background cleanup service (test mode).");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var now = DateTime.UtcNow;//Isikhathi manje(real time tracking)
                                       
                    var expiredUsers = db.AppUser
                        .Where(u => u.DeclinedAt != null && u.DeclinedAt.Value.AddMinutes(1) <= now)
                        .ToList();

                    if (expiredUsers.Any())
                    {
                        var emails = string.Join(", ", expiredUsers.Select(u => u.Email));
                        _logger.LogInformation("[UserCleanupService] Deleting {Count} users: {Emails}", expiredUsers.Count, emails);

                        db.AppUser.RemoveRange(expiredUsers);
                        await db.SaveChangesAsync(stoppingToken);

                        _logger.LogInformation("[UserCleanupService] Removed {Count} declined users.", expiredUsers.Count);
                    }
                    else
                    {
                        _logger.LogDebug("[UserCleanupService] No expired declined users found.");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[UserCleanupService] Exception during cleanup.");
            }

            await Task.Delay(_checkInterval, stoppingToken);
        }

        _logger.LogInformation("[UserCleanupService] Stopping background cleanup service.");
    }
}
