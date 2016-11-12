using Common.Logging;
using Quartz;

namespace Wlitsoft.ProjectSample.QuartzNETWinService.Job
{
    public class Job1 : IJob
    {
        //日志构造者。
        private static readonly ILog Logger = LogManager.GetLogger("job1");

        #region Implementation of IJob

        /// <summary>
        /// Called by the <see cref="T:Quartz.IScheduler" /> when a <see cref="T:Quartz.ITrigger" />
        /// fires that is associated with the <see cref="T:Quartz.IJob" />.
        /// </summary>
        /// <remarks>
        /// The implementation may wish to set a  result object on the
        /// JobExecutionContext before this method exits.  The result itself
        /// is meaningless to Quartz, but may be informative to
        /// <see cref="T:Quartz.IJobListener" />s or
        /// <see cref="T:Quartz.ITriggerListener" />s that are watching the job's
        /// execution.
        /// </remarks>
        /// <param name="context">The execution context.</param>
        public void Execute(IJobExecutionContext context)
        {
            string jobDes = context.JobDetail.Description;
            Logger.Info($"{jobDes}运行");
        }

        #endregion
    }
}
