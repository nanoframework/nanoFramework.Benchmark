using System;

namespace nanoFramework.Benchmark.Result
{
    internal class MethodResult
    {
        private string _methodName;
        private string _meanExecutionTime;
        private string _maxExecutionTime;
        private string _minExecutionTime;
        private TimeSpan _meanExecutionTimeRaw;

        public SingleTestResult[] SingleTestResults { get; }
        internal bool IsBaseline { get; }

        public MethodResult(string methodName, SingleTestResult[] singleTestResults, bool isBaseline)
        {
            _methodName = methodName;
            SingleTestResults = singleTestResults;
            IsBaseline = isBaseline;
        }

        internal string GetMethodName()
        {
            return _methodName;
        }

        internal string GetMeanExecutionTime()
        {
            if (string.IsNullOrEmpty(_meanExecutionTime))
            {
                _meanExecutionTime = $"{GetMeanExecutionTimeRaw().TotalMilliseconds} ms";
            }

            return _meanExecutionTime;
        }

        internal TimeSpan GetMeanExecutionTimeRaw()
        {
            if (string.IsNullOrEmpty(_meanExecutionTime))
            {
                long sumTicks = 0;
                int elemetsCount = 0;

                foreach (var item in SingleTestResults)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    sumTicks += item.ElapsedTime.Ticks;
                    elemetsCount++;
                }

                _meanExecutionTimeRaw = TimeSpan.FromTicks(sumTicks / elemetsCount);
            }

            return _meanExecutionTimeRaw;
        }

        internal string GetMinExecutionTime()
        {
            if (string.IsNullOrEmpty(_minExecutionTime))
            {
                double minTime = double.MaxValue;
                foreach (var item in SingleTestResults)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (item.ElapsedTime.TotalMilliseconds < minTime)
                    {
                        minTime = item.ElapsedTime.TotalMilliseconds;
                    }
                }

                _minExecutionTime = $"{minTime:N0} ms";
            }

            return _minExecutionTime;
        }

        internal string GetMaxExecutionTime()
        {
            if (string.IsNullOrEmpty(_maxExecutionTime))
            {
                double maxTime = 0;
                foreach (var item in SingleTestResults)
                {
                    if (item == null)
                    {
                        continue;
                    }

                    if (item.ElapsedTime.TotalMilliseconds > maxTime)
                    {
                        maxTime = item.ElapsedTime.TotalMilliseconds;
                    }
                }

                _maxExecutionTime = $"{maxTime:N0} ms";
            }

            return _maxExecutionTime;
        }
    }
}
