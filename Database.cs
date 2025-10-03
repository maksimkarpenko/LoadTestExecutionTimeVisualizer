using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TestSynchronizer {

    class DataContext : DbContext {

        const string ConnectionString = "Data Source=xaf-tests.corp.devexpress.com;Initial Catalog=LoadTests;Integrated Security=False;User=sa;Password=dx;Encrypt=False;";
        public DbSet<Test> Test { get; set; }
        public DbSet<TestOperation> TestOperation { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer(ConnectionString);
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
        public ICollection<TestOperation> Operations { get; set; } = new ObservableCollection<TestOperation>();

        public override string ToString() {
            string name = TestName.Replace("MainDemo.NET.EFCore.LoadTests.MainDemoLoadTests.", "");
            return $"{TestDate.ToString("dd.MM HH:mm")} {name}, {Workers} workers";
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

    static class DatabaseHelper {
        public const string Version = "25.2";
        public static List<Test> GetTests() {
            using (var dbContext = new DataContext()) {
                return dbContext.Test.Where(t => t.Version == Version).OrderBy(t => t.TestDate).ToList();
            }
        }
        public static void DeleteTest(int testId) {
            using (var dbContext = new DataContext()) {
                var test = dbContext.Test.FirstOrDefault(t => t.Id == testId);
                var operations = dbContext.TestOperation.Where(t => t.Test.Id == testId).ToList();
                dbContext.Test.Remove(test);
                foreach (var oper in operations) {
                    dbContext.TestOperation.Remove(oper);
                }
                dbContext.SaveChanges();
            }
        }
        public static List<TestExecutionTimeMetric> GetTestOperations(int testId) {
            using (var dbContext = new DataContext()) {
                return dbContext.TestOperation.Where(t => t.Test.Id == testId).Select(t => new TestExecutionTimeMetric() {
                    Test = t.Test,
                    Operation = t.Operation,
                    StepNumber = t.StepNumber
                }).Distinct().OrderBy(t => t.StepNumber).ToList();
            }
        }
        public static double[] GetTestExecutionTime(TestExecutionTimeMetric metric) {
            using (var dbContext = new DataContext()) {
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
