using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using log4net;

namespace Bekk.dotnetintro.Blog.Data.Migrations
{
    public class Migrate
    {
        public static string DefaultProvider = "SqlServer2008";
        private static readonly ILog _log = LogManager.GetLogger(typeof(Migrate));

        public static void MigrateToLatestVersion(string connectionString)
        {
            var migrationContext = new RunnerContext(new Log4NetAnnouncer())
            {
                Connection = connectionString,
                Database = DefaultProvider,
                Target = typeof(Migrate).Assembly.GetName().Name
            };

            var executor = new TaskExecutor(migrationContext);
            executor.Execute();
        }

        class Log4NetAnnouncer : Announcer
        {
            public override bool ShowSql
            {
                get { return true; }
                set
                {
                    base.ShowSql = value;
                }
            }

            public override void Write(string message, bool escaped)
            {
                _log.Debug(message);
            }

            public override void Sql(string sql)
            {
                _log.Debug(sql);
            }
        }
    }
}

