using System.ServiceProcess;
using Common.Logging;
using Quartz;
using Quartz.Impl;

namespace Wlitsoft.ProjectSample.QuartzNETWinService
{
    public partial class MainService : ServiceBase
    {
        #region 私有属性

        //日志记录这。
        private readonly ILog _logger;

        //调度器。
        private readonly IScheduler _scheduler;

        #endregion

        #region 构造方法

        /// <summary>
        /// 初始化 <see cref="MainService"/> 类的新实例。
        /// </summary>
        public MainService()
        {
            InitializeComponent();
            this._logger = LogManager.GetLogger(this.GetType());
            StdSchedulerFactory factory = new StdSchedulerFactory();
            this._scheduler = factory.GetScheduler();
        }

        #endregion

        protected override void OnStart(string[] args)
        {
            this._scheduler.Start();
            this._logger.Info("服务启动");
        }

        protected override void OnStop()
        {
            if (!this._scheduler.IsShutdown)
                this._scheduler.Shutdown();
            this._logger.Info("服务停止");
        }

        protected override void OnPause()
        {
            this._scheduler.PauseAll();
            base.OnPause();
        }

        protected override void OnContinue()
        {
            this._scheduler.ResumeAll();
            base.OnContinue();
        }
    }
}
