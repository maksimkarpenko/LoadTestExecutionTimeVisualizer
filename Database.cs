using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;

namespace TestSynchronizer {

    class DataContext : DbContext {

        public DbSet<Test> Test { get; set; }
        public DbSet<TestOperation> TestOperation { get; set; }
        readonly string connectionString;
        public DataContext(string connectionStringName) {
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }
    }

    class Test {
        public int Id { get; set; }
        public string Version { get; set; }
        public bool IsRunOnFarm { get; set; }
        public DateTime TestDate { get; set; }
        [MaxLength(255)]
        public string AppName { get; set; }
        [MaxLength(255)]
        public string TestName { get; set; }
        public int Workers { get; set; }
        public int CpuCores { get; set; }
        public int Memory { get; set; }
        public string Label { get; set; }
        public ICollection<TestOperation> Operations { get; set; } = new ObservableCollection<TestOperation>();

        public override string ToString() {
            string name = TestName.Replace("MainDemo.NET.EFCore.LoadTests.MainDemoLoadTests.", "");
            string label = string.IsNullOrEmpty(Label) ? "" : $" [{Label}]";
            string cpuAndMemory = CpuCores != 0 ? $"{CpuCores}CPU/{Memory / 1024.0}Gb" : "";
            return $"{TestDate.ToString("dd.MM HH:mm")}{label} {name}, {Workers} workers, {cpuAndMemory}";
        }
    }

    class TestOperation {
        public int Id { get; set; }
        public Test Test { get; set; }
        public int StepNumber { get; set; }
        [MaxLength(255)]
        public string Operation { get; set; }
        public double ExecutionTime { get; set; }
    }

    class DatabaseHelper {
        public const string Version = "25.2";
        readonly string connectionStringName;
        public DatabaseHelper(string connectionStringName) {
            this.connectionStringName = connectionStringName;
        }
        public List<Test> GetTests() {
            using (var dbContext = new DataContext(connectionStringName)) {
                return dbContext.Test.Where(t => t.Version == Version).OrderBy(t => t.TestDate).ToList();
            }
        }
        public void DeleteTest(int testId) {
            using (var dbContext = new DataContext(connectionStringName)) {
                var test = dbContext.Test.FirstOrDefault(t => t.Id == testId);
                var operations = dbContext.TestOperation.Where(t => t.Test.Id == testId).ToList();
                dbContext.Test.Remove(test);
                foreach (var oper in operations) {
                    dbContext.TestOperation.Remove(oper);
                }
                dbContext.SaveChanges();
            }
        }
        public List<TestExecutionTimeMetric> GetTestOperations(int testId) {
            using (var dbContext = new DataContext(connectionStringName)) {
                return dbContext.TestOperation.Where(t => t.Test.Id == testId).Select(t => new TestExecutionTimeMetric() {
                    Test = t.Test,
                    Operation = t.Operation,
                    StepNumber = t.StepNumber
                }).Distinct().OrderBy(t => t.StepNumber).ToList();
            }
        }
        public double[] GetTestExecutionTime(TestExecutionTimeMetric metric) {
            using (var dbContext = new DataContext(connectionStringName)) {
                return dbContext.TestOperation.Where(t => t.Test.Id == metric.Test.Id && t.StepNumber == metric.StepNumber && t.Operation == metric.Operation)
                    .Select(t => t.ExecutionTime)
                    .OrderBy(t => t).ToArray();
            }
        }
    }

    class TestExecutionTimeMetric {
        public Test Test;
        public string TestName => Test.ToString();
        public string Operation;
        public int StepNumber;
    }
}
