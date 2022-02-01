using DbUp;
using DbUp.Engine;
using HelloWorldCore6.Data;
using Serilog;

namespace HelloWorldCore6.Infrastructure
{
    public class Database
    {
        public static void UpgradeDatabase(string connectionString)
        {
            var engine = DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsEmbeddedInAssembly(typeof(MyDbContext).Assembly)
            .LogToAutodetectedLog()
            .Build();

            Log.Debug("DISCOVERED SCRIPTS :");
            foreach (SqlScript discoveredScript in engine.GetDiscoveredScripts())
            {
                Log.Debug(discoveredScript.Name);
            }
            Log.Debug("SCRIPTS TO EXECUTE :");
            foreach (SqlScript scriptToExecute in engine.GetScriptsToExecute())
            {
                Log.Debug(scriptToExecute.Name);
            }

            bool isUpgradeRequired = engine.IsUpgradeRequired();
            if (!isUpgradeRequired)
            {
                Log.Information("Database CaNavire is already up to date.");
                return;
            }

            Log.Information("Database CaNavire need an upgrade.");

            DatabaseUpgradeResult migrationResult = engine.PerformUpgrade();

            if (!migrationResult.Successful)
            {
                Log.Fatal("Database CaNavire upgrade failed.", migrationResult.Error);
                throw new Exception("Database CaNavire upgrade failed.", migrationResult.Error);
            }

            Log.Information("Database CaNavire is up to date.");
        }
    }
}
